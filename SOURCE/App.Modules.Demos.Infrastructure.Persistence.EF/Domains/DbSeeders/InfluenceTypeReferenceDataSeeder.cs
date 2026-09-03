using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Enums;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema.Implementations;
using App.Modules.Sys.Shared.Domains.Indexes;
using App.Modules.Sys.Shared.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>
    /// Seeds the <see cref="InfluenceTypeReferenceData"/> table from the
    /// <see cref="InfluenceType"/> enum.
    /// <para>
    /// Each enum value is mapped to a deterministic GUID via
    /// <see cref="DeterministicGuid.FromEnum{TEnum}"/> so that code can
    /// resolve well-known IDs without a database lookup.
    /// </para>
    /// </summary>
    public sealed class InfluenceTypeReferenceDataSeeder : EFDataSeederBase
    {
        /// <inheritdoc />
        public override void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfluenceTypeReferenceData>().HasData(
                Create(InfluenceType.Undefined, "Undefined", "Influence type has not been set.", 0),
                Create(InfluenceType.NotApplicable, "Not Applicable", "Influence type is not applicable in this context.", 1),
                Create(InfluenceType.Unspecified, "Unspecified", "Influence type was not specified.", 2),
                Create(InfluenceType.Unknown, "Unknown", "Influence type is not known.", 3),
                Create(InfluenceType.Direct, "Direct", "Direct personal influence through mentorship, collaboration, or immediate contact.", 4),
                Create(InfluenceType.Indirect, "Indirect", "Indirect influence through works, writings, or cultural legacy rather than personal contact.", 5),
                Create(InfluenceType.Intellectual, "Intellectual", "Influence through ideas, theories, or intellectual frameworks.", 6),
                Create(InfluenceType.Spiritual, "Spiritual", "Influence through religious thought, mysticism, or faith traditions.", 7),
                Create(InfluenceType.Artistic, "Artistic", "Influence through creative expression in visual, literary, or performing arts.", 8),
                Create(InfluenceType.Scientific, "Scientific", "Influence through empirical discovery, experimentation, or technological innovation.", 9),
                Create(InfluenceType.Philosophical, "Philosophical", "Influence through systems of thought, ethics, logic, or metaphysics.", 10)
            );
        }

        private static InfluenceTypeReferenceData Create(InfluenceType enumValue, string title, string description, int displayOrder)
        {
            return new InfluenceTypeReferenceData
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
