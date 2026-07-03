using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Configuration.ReferenceData
{
    /// <summary>
    /// EF Core schema configuration for <see cref="InfluenceStrengthReferenceData"/>.
    /// <para>
    /// Maps the influence strength reference data table in the ReferenceData schema.
    /// Seed data is provided by <c>InfluenceStrengthReferenceDataSeeder</c>.
    /// </para>
    /// </summary>
    public sealed class InfluenceStrengthReferenceDataEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<InfluenceStrengthReferenceData>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<InfluenceStrengthReferenceData> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.InfluenceStrengthReferenceData, DbSchemaSchemaNameConstants.ReferenceData);
            builder.DefineIHasGuidId(ref order);
            builder.DefineDefaultReferenceDataEntityBase(ref order);
            builder.DefineInt(x => x.EnumValue, ref order, isRequired: false);
            builder.HasIndex(e => e.EnumValue)
                .HasDatabaseName($"IX_{DbSchemaTableNameConstants.InfluenceStrengthReferenceData}_EnumValue")
                .HasFilter("[EnumValue] IS NOT NULL")
                .IsUnique();
            builder.DefineIHasTimestampRecordStateAndAuditability(ref order);
        }
    }
}
