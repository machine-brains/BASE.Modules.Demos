using System.Reflection;
using System.Security.Cryptography;
using App.Modules.Demos.Infrastructure.Domains.Media.Licenses;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using DemosModuleDbContext = App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.DbContexts.Implementations;
using App.Modules.Sys.Infrastructure.Media.Domains.Media.Models;
using App.Modules.Sys.Infrastructure.Media.Domains.Media.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Domains.Infrastructure.Models.Implementations;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using App.Modules.Sys.Shared.Domains.Persistence.ObjectStorage;
using App.Modules.Sys.Shared.Domains.Persistence.ObjectStorage.Models.Enums;
using App.Modules.Sys.Shared.Domains.Persistence.ObjectStorage.Services;
using App.Modules.Sys.Substrate.Domains.Indexes;
using App.Modules.Sys.Shared.Domains.Media;
using App.Modules.Sys.Substrate.Domains.Measurements.Models;
using App.Modules.Sys.Substrate.Domains.Measurements.Models.Enums;
using App.Modules.Sys.Substrate.Domains.Models;
using App.Modules.Sys.Substrate.Domains.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SysModuleDbContext = App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.DbContexts.Implementations.ModuleDbContext;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.Media
{
    /// <summary>
    /// Seeds reviewed, square Wikimedia portrait crops into public MediaContent records and links them to Demos profiles.
    /// </summary>
    /// <remarks>
    /// The flow is embedded portrait asset -> public object storage -> MediaContent -> profile MediaContentFK -> Read DTO -> client media proxy.
    /// The stored image is a 512px face-to-sternum crop; source and attribution remain in MediaContent.Description. The seeder uses
    /// deterministic keys and never exposes the original storage path through the profile DTO.
    /// </remarks>
    public sealed class DemosProfilePortraitMediaDbSeederInitialiser : IModuleDbSeederInitialiser
    {
        public string InitialiserName => "DemosProfilePortraitMedia";
        public int Order => 195;

        public void Initialise(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            using IServiceScope scope = serviceProvider.CreateScope();
            this.InitialiseAsync(scope.ServiceProvider).GetAwaiter().GetResult();
        }

        private async Task InitialiseAsync(IServiceProvider serviceProvider)
        {
            IAppLogger logger = serviceProvider.GetRequiredService<IAppLogger>();
            IObjectStorageService storage = serviceProvider.GetRequiredService<IObjectStorageService>();
            IImageManipulationService imageManipulationService = serviceProvider.GetRequiredService<IImageManipulationService>();
            if (!storage.IsAvailable || !await storage.EnsureContainerExistsAsync(StorageContainerType.Public).ConfigureAwait(false))
            {
                logger.LogWarning("Demos portrait media seeding skipped because public object storage is unavailable.");
                return;
            }

            DemosModuleDbContext dbContext = serviceProvider.GetRequiredService<DemosModuleDbContext>();
            SysModuleDbContext sysDbContext = serviceProvider.GetRequiredService<SysModuleDbContext>();
            List<DiscovererProfile> discovererProfiles = await dbContext.DiscovererProfiles.ToListAsync().ConfigureAwait(false);
            List<CreatorProfile> creatorProfiles = await dbContext.CreatorProfiles.ToListAsync().ConfigureAwait(false);
            List<BelieverProfile> believerProfiles = await dbContext.BelieverProfiles.ToListAsync().ConfigureAwait(false);
            await this.SeedProfilesAsync(dbContext, sysDbContext, storage, imageManipulationService, logger, discovererProfiles).ConfigureAwait(false);
            await this.SeedProfilesAsync(dbContext, sysDbContext, storage, imageManipulationService, logger, creatorProfiles).ConfigureAwait(false);
            await this.SeedProfilesAsync(dbContext, sysDbContext, storage, imageManipulationService, logger, believerProfiles).ConfigureAwait(false);
        }

        private async Task SeedProfilesAsync<TEntity>(DemosModuleDbContext dbContext, SysModuleDbContext sysDbContext, IObjectStorageService storage, IImageManipulationService imageManipulationService, IAppLogger logger, IReadOnlyCollection<TEntity> profiles)
            where TEntity : class, IHasMediaReference, IHasTitle
        {
            foreach (TEntity profile in profiles)
            {
                if (!DemosPortraitCatalog.Entries.TryGetValue(profile.Title, out DemosPortraitCatalog.PortraitDefinition? portrait))
                {
                    continue;
                }

                string mediaKey = $"demos:portrait:{portrait.AssetKey}";
                MediaContent? mediaContent = await sysDbContext.MediaContents.FirstOrDefaultAsync(candidate => candidate.Key == mediaKey).ConfigureAwait(false);
                if (mediaContent is null)
                {
                    byte[]? sourceBytes = this.TryReadEmbeddedPortrait(portrait.AssetKey);
                    if (sourceBytes is null)
                    {
                        logger.LogWarning($"Demos portrait asset '{portrait.AssetKey}' is not packaged; retaining the profile fallback icon.");
                        continue;
                    }

                    byte[] bytes = imageManipulationService.ResizeAndConvert(
                        sourceBytes,
                        new PixelDimensions(512, 512),
                        ImageFormat.Webp);
                    string relativeBlobPath = $"demos/portraits/{portrait.AssetKey}.webp";
                    await using MemoryStream stream = new(bytes, writable: false);
                    await storage.UploadAsync(StorageContainerType.Public, relativeBlobPath, stream, "image/webp").ConfigureAwait(false);
                    mediaContent = new MediaContent
                    {
                        Id = DeterministicGuid.FromString(mediaKey),
                        Key = mediaKey,
                        Title = $"{profile.Title} portrait",
                        Description = $"512px square face-to-sternum portrait crop. Source: {portrait.SourceUrl}. Attribution: {portrait.AttributionUrl}. Wikimedia Commons source; verify page license before redistribution.",
                        BlobPath = $"{ObjectStorageConstants.Containers.Public}/{relativeBlobPath}",
                        MimeType = "image/webp",
                        ContentHash = Convert.ToHexString(SHA256.HashData(bytes)),
                        ContentHashAlgorithm = ObjectStorageConstants.Defaults.ContentHashAlgorithm,
                        ContentSizeBytes = bytes.LongLength,
                        IntrinsicDimensions = new MediaDimensions(512m, 512m, MediaDimensionUnit.Pixels),
                    };
                    sysDbContext.MediaContents.Add(mediaContent);
                }

                profile.MediaReferenceKind = MediaReferenceKind.Media;
                profile.MediaContentFK = mediaContent.Id;
            }

            await sysDbContext.SaveChangesAsync().ConfigureAwait(false);
            await dbContext.SaveChangesAsync().ConfigureAwait(false);
            logger.LogInformation($"Demos portrait media reconciliation completed for {typeof(TEntity).Name}.");
        }

        private byte[]? TryReadEmbeddedPortrait(string assetKey)
        {
            string suffix = $".Assets.Portraits.{assetKey}.webp";
            string? resourceName = typeof(DemosProfilePortraitMediaDbSeederInitialiser).Assembly
                .GetManifestResourceNames()
                .SingleOrDefault(candidate => candidate.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
            if (resourceName is null)
            {
                return null;
            }

            using Stream? stream = typeof(DemosProfilePortraitMediaDbSeederInitialiser).Assembly.GetManifestResourceStream(resourceName);
            if (stream is null)
            {
                return null;
            }

            using MemoryStream buffer = new();
            stream.CopyTo(buffer);
            return buffer.ToArray();
        }
    }
}
