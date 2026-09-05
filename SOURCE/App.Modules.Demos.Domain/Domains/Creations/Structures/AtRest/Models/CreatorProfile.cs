using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models
{
    /// <summary>
    /// Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.
    /// </summary>
    public class CreatorProfile : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
    {
        /// <summary>Opaque boundary reference to the Person in Social module.</summary>
        public Guid PersonId { get; set; }
        /// <inheritdoc/>
        public string Title { get; set; } = string.Empty;
        /// <inheritdoc/>
        public string? Description { get; set; }
        /// <summary>Approximate start year of active era. Negative = BCE.</summary>
        public int? EraFrom { get; set; }
        /// <summary>Approximate end year of active era. Negative = BCE.</summary>
        public int? EraTo { get; set; }
        /// <summary>FK to the <c>CreativeMediumReferenceData</c> record identifying the primary creative medium.</summary>
        public Guid CreativeMediumId { get; set; }
        /// <summary>Nationality or cultural origin.</summary>
        public string? Nationality { get; set; }
    }
}
