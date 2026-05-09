namespace App.Modules.Demos.Application.Domains.Creators.Dtos
{
    /// <summary>
    /// Write DTO for <c>Creation</c>. Used for create and update operations.
    /// </summary>
    public class CreationWriteDto
    {
        /// <summary>FK to the associated CreatorProfile.</summary>
        public Guid CreatorProfileId { get; set; }

        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Year of creation. Negative = BCE.</summary>
        public int Year { get; set; }

        /// <summary>Name of the creation location.</summary>
        public string? LocationName { get; set; }

        /// <summary>FK to the CreativeMediumReferenceData record.</summary>
        public Guid CreativeMediumId { get; set; }

        /// <summary>Nationality or cultural origin.</summary>
        public string? Nationality { get; set; }

        /// <summary>Genre or sub-category within the medium.</summary>
        public string? Genre { get; set; }

        /// <summary>Statement of cultural or artistic significance.</summary>
        public string? Significance { get; set; }
    }
}
