using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Domain.Domains.Influences.Structures.Entities
{
    /// <summary>
    /// Directional influence relationship between two historical profiles.
    /// Captures who influenced whom, the nature of that influence, and its strength.
    /// Both profile references are opaque boundary FKs — no navigation properties.
    /// </summary>
    public class Influence : DefaultEntityBase, IHasDescriptionNullable
    {
        /// <summary>Boundary FK of the profile that exerted the influence.</summary>
        public Guid InfluencerProfileId { get; set; }

        /// <summary>FK to the <c>ProfileTypeReferenceData</c> record identifying the influencer's profile type.</summary>
        public Guid InfluencerProfileTypeId { get; set; }

        /// <summary>Boundary FK of the profile that was influenced.</summary>
        public Guid InfluencedProfileId { get; set; }

        /// <summary>FK to the <c>ProfileTypeReferenceData</c> record identifying the influenced figure's profile type.</summary>
        public Guid InfluencedProfileTypeId { get; set; }

        /// <inheritdoc/>
        public string? Description { get; set; }

        /// <summary>FK to the <c>InfluenceTypeReferenceData</c> record categorising the nature of influence.</summary>
        public Guid InfluenceTypeId { get; set; }

        /// <summary>FK to the <c>InfluenceStrengthReferenceData</c> record quantifying the magnitude of influence.</summary>
        public Guid InfluenceStrengthId { get; set; }
    }
}
