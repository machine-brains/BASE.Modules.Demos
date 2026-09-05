using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Enums;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema.Implementations;
using App.Modules.Sys.Substrate.Domains.Indexes;
using App.Modules.Sys.Substrate.Domains.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>
    /// Seeds the <see cref="CreativeMediumReferenceData"/> table from the
    /// <see cref="CreativeMedium"/> enum.
    /// <para>
    /// Each enum value is mapped to a deterministic GUID via
    /// <see cref="DeterministicGuid.FromEnum{TEnum}"/> so that code can
    /// resolve well-known IDs without a database lookup.
    /// </para>
    /// </summary>
    public sealed class CreativeMediumReferenceDataSeeder : EFDataSeederBase
    {
        /// <inheritdoc />
        public override void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreativeMediumReferenceData>().HasData(
                Create(CreativeMedium.Undefined, "Undefined", "Creative medium has not been set.", 0),
                Create(CreativeMedium.NotApplicable, "Not Applicable", "Creative medium is not applicable in this context.", 1),
                Create(CreativeMedium.Unspecified, "Unspecified", "Creative medium was not specified.", 2),
                Create(CreativeMedium.Unknown, "Unknown", "Creative medium is not known.", 3),
                Create(CreativeMedium.Literature, "Literature", "Written works including prose, poetry, drama, and non-fiction.", 4),
                Create(CreativeMedium.VisualArt, "Visual Art", "Painting, sculpture, printmaking, and other visual art forms.", 5),
                Create(CreativeMedium.Music, "Music", "Composition, performance, and musical theory across all traditions.", 6),
                Create(CreativeMedium.Architecture, "Architecture", "Design and construction of buildings, monuments, and planned spaces.", 7),
                Create(CreativeMedium.Science, "Science", "Empirical inquiry, experimentation, and systematic knowledge production.", 8),
                Create(CreativeMedium.Technology, "Technology", "Applied invention, engineering, and tool-making for practical ends.", 9),
                Create(CreativeMedium.Philosophy, "Philosophy", "Systems of thought, ethics, logic, and metaphysical inquiry.", 10)
            );
        }

        private static CreativeMediumReferenceData Create(CreativeMedium enumValue, string title, string description, int displayOrder)
        {
            return new CreativeMediumReferenceData
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
