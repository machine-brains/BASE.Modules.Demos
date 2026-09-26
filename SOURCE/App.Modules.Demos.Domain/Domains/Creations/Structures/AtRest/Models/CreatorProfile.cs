using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Infrastructure.Models.Implementations;
using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;
using App.Modules.Sys.Substrate.Domains.Models.Enums;

namespace App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models
{
    /// <summary>
    /// Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.
    /// </summary>
    // Global historical demo data has no workspace owner or per-principal grant.
    public class CreatorProfile : DefaultEntityBase, IHasTitle, IHasDescriptionNullable, IHasMediaReference, IShareFilterExemptEntity
    {
        /// <summary>Opaque boundary reference to the Person in Social module.</summary>
        public Guid PersonId { get; set; }

        public MediaReferenceKind MediaReferenceKind { get; set; } = MediaReferenceKind.None;
        public string? MediaFontKey { get; set; }
        public Guid? MediaContentFK { get; set; }
        public MediaContent? MediaContent { get; set; }
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
