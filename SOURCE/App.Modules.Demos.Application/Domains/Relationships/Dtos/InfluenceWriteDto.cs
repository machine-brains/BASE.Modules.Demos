namespace App.Modules.Demos.Application.Domains.Relationships.Dtos
{
    /// <summary>
    /// Write DTO for <c>Influence</c>. Used for create and update operations.
    /// </summary>
    public class InfluenceWriteDto
    {
        /// <summary>FK of the influencing profile.</summary>
        public Guid InfluencerProfileId { get; set; }

        /// <summary>FK to the ProfileTypeReferenceData record for the influencer.</summary>
        public Guid InfluencerProfileTypeId { get; set; }

        /// <summary>FK of the influenced profile.</summary>
        public Guid InfluencedProfileId { get; set; }

        /// <summary>FK to the ProfileTypeReferenceData record for the influenced figure.</summary>
        public Guid InfluencedProfileTypeId { get; set; }

        /// <summary>Optional description of the relationship.</summary>
        public string? Description { get; set; }

        /// <summary>FK to the InfluenceTypeReferenceData record categorising the nature of influence.</summary>
        public Guid InfluenceTypeId { get; set; }

        /// <summary>FK to the InfluenceStrengthReferenceData record quantifying the magnitude of influence.</summary>
        public Guid InfluenceStrengthId { get; set; }
    }
}
