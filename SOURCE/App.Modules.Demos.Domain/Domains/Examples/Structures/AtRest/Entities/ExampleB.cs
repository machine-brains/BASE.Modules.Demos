using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities
{
    /// <summary>Ordered child example belonging to an ExampleA parent.</summary>
    /// <remarks>ExampleAId remains an explicit identity-only cross-aggregate reference for the REST hierarchy.</remarks>
#pragma warning disable BASE0001
    public class ExampleB : DefaultEntityBase, IHasName, IHasDescriptionNullable, IHasWorkspaceFK, IHasFromToUtcNullable
    {
        /// <summary>Gets or sets the legacy compatibility workspace scope for this pilot row.</summary>
        /// <remarks>The child scope is enforced independently of <see cref="ExampleAId"/> by the governed repository filter.</remarks>
        public Guid WorkspaceFK { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset? FromUtc { get; set; }

        /// <inheritdoc/>
        public DateTimeOffset? ToUtc { get; set; }

        /// <summary>Gets or sets the optional WGS84 latitude in degrees.</summary>
        /// <remarks>WGS84 is the Demos spatial contract; map projection and camera state belong to the client Presenter.</remarks>
        public double? Latitude { get; set; }

        /// <summary>Gets or sets the optional WGS84 longitude in degrees.</summary>
        /// <remarks>WGS84 is the Demos spatial contract; map projection and camera state belong to the client Presenter.</remarks>
        public double? Longitude { get; set; }

        /// <summary>Gets or sets the parent ExampleA identifier.</summary>
        public Guid ExampleAId { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? Description { get; set; }

        /// <summary>Gets or sets the deterministic display order within the parent.</summary>
        public int SortOrder { get; set; }
    }
#pragma warning restore BASE0001
}