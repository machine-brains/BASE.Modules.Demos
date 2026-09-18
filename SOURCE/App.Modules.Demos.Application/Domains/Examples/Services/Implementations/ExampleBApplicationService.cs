using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Examples.Repositories;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Demos.Domain.Domains.Examples.Validation;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;
using App.Modules.Sys.Shared.Social.Models;
using App.Modules.Sys.Shared.Social.Services;
using App.Modules.Sys.Application.Domains.Users.Context.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Demos.Application.Domains.Examples.Services.Implementations
{
    /// <summary>CRUST application service for ordered Demos ExampleB children.</summary>
    /// <remarks>ExampleB remains a separate capability; callers compose the parent/child hierarchy from explicit IDs.</remarks>
    public class ExampleBApplicationService
        : CrustStateAppServiceBase<ExampleB, ExampleBReadDto, ExampleBWriteDto, ExampleBWriteDto>,
          IExampleBApplicationService
    {
        /// <summary>Initializes the ExampleB application service.</summary>
        private readonly ModuleDbContext _dbContext;
                private readonly IExampleARepository _exampleARepository;
                private readonly IExampleBRepository _exampleBRepository;
                private readonly IReadOnlyList<IPersonIdentityResolverService> _identityResolvers;
                private readonly IUserContextService _userContext;

        public ExampleBApplicationService(
            IExampleBRepository repository,
            IExampleARepository exampleARepository,
            ModuleDbContext dbContext,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService,
            IEnumerable<IPersonIdentityResolverService> identityResolvers,
            IUserContextService userContext)
            : base(repository, objectMappingService, loggingService)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._exampleARepository = exampleARepository ?? throw new ArgumentNullException(nameof(exampleARepository));
            this._exampleBRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            this._identityResolvers = identityResolvers?.ToList() ?? throw new ArgumentNullException(nameof(identityResolvers));
            this._userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        /// <summary>Creates a child record under a visible parent in the authenticated current workspace.</summary>
        /// <remarks>The parent ID is validated through the parent repository and workspace scope is injected server-side.</remarks>
        public override async Task<ExampleBReadDto> CreateAsync(ExampleBWriteDto dto, CancellationToken cancellationToken = default)
        {
            if (!this._userContext.IsAuthenticated)
            {
                throw new UnauthorizedAccessException("An authenticated workspace member is required.");
            }

            if (!this._exampleARepository.QueryById(dto.ExampleAId).Any())
            {
                throw new InvalidOperationException("The selected ExampleA parent is not visible.");
            }

            ExampleSpatialCapabilityValidation.Validate(dto.Latitude, dto.Longitude);
            ExampleB entity = this.ObjectMappingService.Map<ExampleBWriteDto, ExampleB>(dto);
            entity.WorkspaceFK = this._userContext.CurrentWorkspaceId;
            ExampleB created = await this._exampleBRepository.CreateAsync(entity, cancellationToken).ConfigureAwait(false);
            return this.ObjectMappingService.Map<ExampleB, ExampleBReadDto>(created);
        }

        /// <summary>Updates a child without allowing ordinary updates to reparent it.</summary>
        /// <remarks>Explicit reparenting is deferred to a named flow; the normal update contract preserves the original ExampleAId and workspace scope.</remarks>
        public override async Task<ExampleBReadDto> UpdateAsync(Guid id, ExampleBWriteDto dto, CancellationToken cancellationToken = default)
        {
            ExampleB existing = await this._exampleBRepository.GetForUpdateAsync(id, cancellationToken).ConfigureAwait(false)
                ?? throw new InvalidOperationException("ExampleB with ID " + id + " was not found.");

            if (dto.ExampleAId != existing.ExampleAId)
            {
                throw new InvalidOperationException("ExampleB cannot be reparented through the ordinary update contract.");
            }

            ExampleSpatialCapabilityValidation.Validate(dto.Latitude, dto.Longitude);
            this.ObjectMappingService.Map<ExampleBWriteDto, ExampleB>(dto, existing);
            existing.ExampleAId = dto.ExampleAId;
            existing.WorkspaceFK = this._userContext.CurrentWorkspaceId;
            ExampleB updated = await this._exampleBRepository.UpdateAsync(existing, cancellationToken).ConfigureAwait(false);
            return this.ObjectMappingService.Map<ExampleB, ExampleBReadDto>(updated);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<ExampleBReadDto>> GetByExampleAAsync(Guid exampleAId, CancellationToken cancellationToken = default)
        {
            if (exampleAId == Guid.Empty || !await this.HasAuthenticatedIdentityAsync(cancellationToken).ConfigureAwait(false))
            {
                return Array.Empty<ExampleBReadDto>();
            }

            // The parent query is governed by the same repository visibility path;
            // a child identifier or transport filter cannot disclose a hidden parent.
            bool parentVisible = this._exampleARepository.QueryById(exampleAId)
                .Any(example => example.IsActive);
            if (!parentVisible)
            {
                return Array.Empty<ExampleBReadDto>();
            }

            return await this._exampleBRepository.QueryByExampleAId(exampleAId)
                .Select(example => new ExampleBReadDto
                {
                    Id = example.Id,
                    ExampleAId = example.ExampleAId,
                    Name = example.Name,
                    Description = example.Description,
                    SortOrder = example.SortOrder,
                    FromUtc = example.FromUtc,
                    ToUtc = example.ToUtc,
                    Latitude = example.Latitude,
                    Longitude = example.Longitude,
                })
                .ToListAsync(cancellationToken);
        }

        private async Task<bool> HasAuthenticatedIdentityAsync(CancellationToken cancellationToken)
        {
            foreach (IPersonIdentityResolverService resolver in this._identityResolvers.OrderBy(item => item.IsLiteMode))
            {
                IPersonIdentityInfo? identity = await resolver.GetCurrentUserIdentityAsync(cancellationToken).ConfigureAwait(false);
                if (identity?.Id is Guid identityId && identityId != Guid.Empty && identity.PersonaId is Guid personaId && personaId != Guid.Empty)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<ExampleBReadDto>> GetDeveloperDemoAsync(CancellationToken cancellationToken = default)
        {
            return await this._dbContext.ExampleBs
                .IgnoreQueryFilters()
                .AsNoTracking()
                .OrderBy(example => example.ExampleAId)
                .ThenBy(example => example.SortOrder)
                .Select(example => new ExampleBReadDto
                {
                    Id = example.Id,
                    ExampleAId = example.ExampleAId,
                    Name = example.Name,
                    Description = example.Description,
                    SortOrder = example.SortOrder,
                    FromUtc = example.FromUtc,
                    ToUtc = example.ToUtc,
                    Latitude = example.Latitude,
                    Longitude = example.Longitude,
                })
                .ToListAsync(cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<ExampleBReadDto>> GetDeveloperDemoByExampleAAsync(Guid exampleAId, CancellationToken cancellationToken = default)
        {
            return await this._dbContext.ExampleBs
                .IgnoreQueryFilters()
                .Where(example => example.ExampleAId == exampleAId)
                .AsNoTracking()
                .OrderBy(example => example.SortOrder)
                .Select(example => new ExampleBReadDto
                {
                    Id = example.Id,
                    ExampleAId = example.ExampleAId,
                    Name = example.Name,
                    Description = example.Description,
                    SortOrder = example.SortOrder,
                })
                .ToListAsync(cancellationToken);
        }
    }
}