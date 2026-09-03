using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities
{
    /// <summary>
    /// A specific discovery made by a DiscovererProfile.
    /// </summary>
    public class Discovery : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
    {
        /// <summary>Boundary FK to the DiscovererProfile that made this discovery.</summary>
        public Guid DiscovererProfileId { get; set; }
        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;
        /// <inheritdoc/>
        public string? Description { get; set; }
        /// <summary>Year of discovery. Negative = BCE.</summary>
        public int Year { get; set; }
        /// <summary>Name of the location where the discovery occurred.</summary>
        public string? LocationName { get; set; }
        /// <summary>Latitude coordinate of the discovery location.</summary>
        public double? Latitude { get; set; }
        /// <summary>Longitude coordinate of the discovery location.</summary>
        public double? Longitude { get; set; }
        /// <summary>Statement of historical or scientific significance.</summary>
        public string? Significance { get; set; }
    }
}
