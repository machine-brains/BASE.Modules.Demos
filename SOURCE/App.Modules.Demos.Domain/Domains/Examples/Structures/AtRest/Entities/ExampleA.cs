using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities
{
    /// <summary>Stable parent example used by Demos and consumed by Spike.</summary>
    /// <remarks>ExampleB stores this identity without a navigation to preserve the cross-aggregate boundary.</remarks>
#pragma warning disable BASE0001
    public class ExampleA : DefaultEntityBase, IHasTitleAndDescription, IHasWorkspaceFK, IHasFromToUtcNullable
    {
        /// <summary>Gets or sets the legacy compatibility workspace scope for this pilot row.</summary>
        /// <remarks>The current CRUST visibility path uses this field; migration to share-only edges remains a later platform task.</remarks>
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

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>Gets or sets whether this example is active.</summary>
        public bool IsActive { get; set; }
    }
#pragma warning restore BASE0001
}