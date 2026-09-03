using App.Modules.Demos.Domain.Domains.Structures.ReferenceData;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema.Implementations;
using App.Modules.Sys.Shared.Domains.Indexes;
using App.Modules.Sys.Shared.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>
    /// Seeds the <see cref="ProfileTypeReferenceData"/> table from the
    /// <see cref="ProfileType"/> enum.
    /// <para>
    /// Each enum value is mapped to a deterministic GUID via
    /// <see cref="DeterministicGuid.FromEnum{TEnum}"/> so that code can
    /// resolve well-known IDs without a database lookup.
    /// </para>
    /// </summary>
    public sealed class ProfileTypeReferenceDataSeeder : EFDataSeederBase
    {
        /// <inheritdoc />
        public override void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileTypeReferenceData>().HasData(
                Create(ProfileType.Undefined, "Undefined", "Profile type has not been set.", 0),
                Create(ProfileType.NotApplicable, "Not Applicable", "Profile type is not applicable in this context.", 1),
                Create(ProfileType.Unspecified, "Unspecified", "Profile type was not specified.", 2),
                Create(ProfileType.Unknown, "Unknown", "Profile type is not known.", 3),
                Create(ProfileType.Discoverer, "Discoverer", "One who expands the boundaries of knowledge through exploration and inquiry.", 4),
                Create(ProfileType.Creator, "Creator", "One who produces enduring works of art, literature, music, or architecture.", 5),
                Create(ProfileType.Believer, "Believer", "One who shapes civilisation through faith, philosophy, or ideological vision.", 6)
            );
        }

        private static ProfileTypeReferenceData Create(ProfileType enumValue, string title, string description, int displayOrder)
        {
            return new ProfileTypeReferenceData
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
