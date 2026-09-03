using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.ReferenceData
{
    /// <summary>
    /// EF Core schema configuration for <see cref="CreativeMediumReferenceData"/>.
    /// <para>
    /// Maps the creative medium reference data table in the ReferenceData schema.
    /// Seed data is provided by <c>CreativeMediumReferenceDataSeeder</c>.
    /// </para>
    /// </summary>
    public sealed class CreativeMediumReferenceDataEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<CreativeMediumReferenceData>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<CreativeMediumReferenceData> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.CreativeMediumReferenceData, DbSchemaSchemaNameConstants.ReferenceData);
            builder.DefineIHasGuidId(ref order);
            builder.DefineDefaultReferenceDataEntityBase(ref order);
            builder.DefineInt(x => x.EnumValue, ref order, isRequired: false);
            builder.HasIndex(e => e.EnumValue)
                .HasDatabaseName($"IX_{DbSchemaTableNameConstants.CreativeMediumReferenceData}_EnumValue")
                .HasFilter("[EnumValue] IS NOT NULL")
                .IsUnique();
            builder.DefineIHasTimestampMutabilityRecordStateAndAuditability(ref order);
        }
    }
}
