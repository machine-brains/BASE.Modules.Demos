using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Creators.Dtos
{
    /// <summary>
    /// Read DTO for <see cref="Shared.Domains.Contributions.Models.Creation"/>.
    /// </summary>
    public class CreationDto : IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>FK to the associated CreatorProfile.</summary>
        public Guid CreatorProfileId { get; set; }

        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Year of creation. Negative = BCE.</summary>
        public int Year { get; set; }

        /// <summary>FK to the CreativeMediumReferenceData record identifying the creative medium.</summary>
        public Guid CreativeMediumId { get; set; }

        /// <summary>Genre or sub-category.</summary>
        public string? Genre { get; set; }

        /// <summary>Statement of significance.</summary>
        public string? Significance { get; set; }
    }
}
