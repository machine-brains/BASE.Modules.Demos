using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>Writable ExampleB contract for create and update operations.</summary>
    /// <remarks>ExampleAId is an identity-only parent reference; no parent navigation DTO crosses this boundary.</remarks>
    public class ExampleBWriteDto : IHasGuidId, IHasName, IHasDescriptionNullable
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the parent ExampleA identifier.</summary>
        public Guid ExampleAId { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? Description { get; set; }

        /// <summary>Gets or sets the deterministic order within the parent.</summary>
        public int SortOrder { get; set; }

        /// <summary>Gets or sets the optional UTC start of the child item's temporal capability.</summary>
        public DateTimeOffset? FromUtc { get; set; }

        /// <summary>Gets or sets the optional UTC end of the child item's temporal capability.</summary>
        public DateTimeOffset? ToUtc { get; set; }

        /// <summary>Gets or sets the optional WGS84 latitude in degrees.</summary>
        public double? Latitude { get; set; }

        /// <summary>Gets or sets the optional WGS84 longitude in degrees.</summary>
        public double? Longitude { get; set; }
    }
}