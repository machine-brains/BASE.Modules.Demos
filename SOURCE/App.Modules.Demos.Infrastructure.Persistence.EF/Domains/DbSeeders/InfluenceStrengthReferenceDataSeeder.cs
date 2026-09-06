using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Enums;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using App.Modules.Sys.Substrate.Domains.Indexes;
using App.Modules.Sys.Substrate.Domains.Models.Enums;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>
    /// Seeds the <see cref="InfluenceStrengthReferenceData"/> table from the
    /// <see cref="InfluenceStrength"/> enum.
    /// <para>
    /// Each enum value is mapped to a deterministic GUID via
    /// <see cref="DeterministicGuid.FromEnum{TEnum}"/> so that code can
    /// resolve well-known IDs without a database lookup.
    /// </para>
    /// </summary>
    public sealed class InfluenceStrengthReferenceDataSeeder : IEntityDataSeeder<InfluenceStrengthReferenceData>
    {
        /// <inheritdoc />
        public Task<IEnumerable<InfluenceStrengthReferenceData>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            IEnumerable<InfluenceStrengthReferenceData> entries = new List<InfluenceStrengthReferenceData>
            {
                Create(InfluenceStrength.Undefined, "Undefined", "Influence strength has not been set.", 0),
                Create(InfluenceStrength.NotApplicable, "Not Applicable", "Influence strength is not applicable in this context.", 1),
                Create(InfluenceStrength.Unspecified, "Unspecified", "Influence strength was not specified.", 2),
                Create(InfluenceStrength.Unknown, "Unknown", "Influence strength is not known.", 3),
                Create(InfluenceStrength.Minor, "Minor", "A minor influence with limited or localised impact.", 4),
                Create(InfluenceStrength.Moderate, "Moderate", "A moderate influence with noticeable but bounded effect.", 5),
                Create(InfluenceStrength.Major, "Major", "A major influence with broad and lasting significance.", 6),
                Create(InfluenceStrength.Transformative, "Transformative", "A transformative influence that fundamentally reshaped a field, tradition, or civilisation.", 7)
            };
            return Task.FromResult(entries);
        }

        private static InfluenceStrengthReferenceData Create(InfluenceStrength enumValue, string title, string description, int displayOrder)
        {
            return new InfluenceStrengthReferenceData
            {
                Id = DeterministicGuid.FromEnum(enumValue),
                Key = enumValue.ToString(),
                Title = title,
                Description = description,
                Enabled = true,
                RecordMutability = RecordMutabilityType.System,
                EnumValue = (int)enumValue,
                DisplayOrderHint = displayOrder
            };
        }
    }
}
