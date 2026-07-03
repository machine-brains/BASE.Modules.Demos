namespace App.Modules.Demos.Application.Domains.Beliefs.Structures.InTransit.Dtos
{
    /// <summary>
    /// Write DTO for <c>BelieverProfile</c>. Used for create and update operations.
    /// </summary>
    public class BelieverProfileWriteDto
    {
        /// <summary>Boundary reference to the associated Person.</summary>
        public Guid PersonId { get; set; }

        /// <summary>Display title.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }

        /// <summary>Approximate start year of active era. Negative = BCE.</summary>
        public int? EraFrom { get; set; }

        /// <summary>Approximate end year of active era. Negative = BCE.</summary>
        public int? EraTo { get; set; }

        /// <summary>FK to the TraditionReferenceData record.</summary>
        public string? TraditionName { get; set; }

        /// <summary>Nationality or cultural origin.</summary>
        public string? Nationality { get; set; }
    }
}
