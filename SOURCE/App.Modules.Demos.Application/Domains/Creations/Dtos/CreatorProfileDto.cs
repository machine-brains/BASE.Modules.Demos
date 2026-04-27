using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Creators.Dtos
{
    /// <summary>
    /// Read DTO for <see cref="Shared.Domains.Profiles.Models.CreatorProfile"/>.
    /// </summary>
    public class CreatorProfileDto : IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>Boundary reference to the associated Person.</summary>
        public Guid PersonId { get; set; }

        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Approximate start year. Negative = BCE.</summary>
        public int? EraFrom { get; set; }

        /// <summary>Approximate end year. Negative = BCE.</summary>
        public int? EraTo { get; set; }

        /// <summary>FK to the CreativeMediumReferenceData record identifying the primary creative medium.</summary>
        public Guid CreativeMediumId { get; set; }

        /// <summary>Nationality or cultural origin.</summary>
        public string? Nationality { get; set; }
    }
}
