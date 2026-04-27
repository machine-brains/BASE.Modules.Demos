using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Shared.Domains.Contributions.Models
{
    /// <summary>
    /// A specific creative work produced by a CreatorProfile.
    /// </summary>
    public class Creation : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
    {
        /// <summary>Boundary FK to the CreatorProfile that produced this work.</summary>
        public Guid CreatorProfileId { get; set; }

        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string? Description { get; set; }

        /// <summary>Year of creation. Negative = BCE.</summary>
        public int Year { get; set; }

        /// <summary>FK to the <c>CreativeMediumReferenceData</c> record identifying the medium through which this work was expressed.</summary>
        public Guid CreativeMediumId { get; set; }

        /// <summary>Genre or sub-category within the medium.</summary>
        public string? Genre { get; set; }

        /// <summary>Statement of cultural or artistic significance.</summary>
        public string? Significance { get; set; }
    }
}
