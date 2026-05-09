namespace App.Modules.Demos.Application.Domains.Contributions.Dtos
{
    /// <summary>
    /// Write DTO for <c>Contribution</c>. Used for create and update operations.
    /// </summary>
    public class ContributionWriteDto
    {
        /// <summary>Boundary FK to the BelieverProfile that made this contribution.</summary>
        public Guid BelieverProfileId { get; set; }

        /// <summary>Display title of the contribution.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description of the contribution.</summary>
        public string? Description { get; set; }

        /// <summary>Year of contribution. Negative = BCE.</summary>
        public int Year { get; set; }

        /// <summary>Name of the tradition associated with this contribution.</summary>
        public string? TraditionName { get; set; }

        /// <summary>Statement of historical or cultural significance.</summary>
        public string? Significance { get; set; }
    }
}
