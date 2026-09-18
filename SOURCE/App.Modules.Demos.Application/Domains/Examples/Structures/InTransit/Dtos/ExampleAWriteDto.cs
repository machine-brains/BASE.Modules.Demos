using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos
{
    /// <summary>Writable ExampleA contract for create and update operations.</summary>
    /// <remarks>The read DTO derives from this type so infrastructure-managed fields never become input.</remarks>
    public class ExampleAWriteDto : IHasGuidId, IHasTitleAndDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>Gets or sets whether the example is active.</summary>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets the optional UTC start of the example's temporal capability.</summary>
        public DateTimeOffset? FromUtc { get; set; }

        /// <summary>Gets or sets the optional UTC end of the example's temporal capability.</summary>
        public DateTimeOffset? ToUtc { get; set; }

        /// <summary>Gets or sets the optional WGS84 latitude in degrees.</summary>
        public double? Latitude { get; set; }

        /// <summary>Gets or sets the optional WGS84 longitude in degrees.</summary>
        public double? Longitude { get; set; }
    }
}