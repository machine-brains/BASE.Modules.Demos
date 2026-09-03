using App.Modules.Demos.Domain.Domains.Structures.ReferenceData;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.ReferenceData
{
    /// <summary>
    /// EF Core schema configuration for <see cref="ProfileTypeReferenceData"/>.
    /// <para>
    /// Maps the profile type reference data table in the ReferenceData schema.
    /// Seed data is provided by <c>ProfileTypeReferenceDataSeeder</c>.
    /// </para>
    /// </summary>
    public sealed class ProfileTypeReferenceDataEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<ProfileTypeReferenceData>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ProfileTypeReferenceData> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.ProfileTypeReferenceData, DbSchemaSchemaNameConstants.ReferenceData);
            builder.DefineIHasGuidId(ref order);
            builder.DefineDefaultReferenceDataEntityBase(ref order);
            builder.DefineInt(x => x.EnumValue, ref order, isRequired: false);
            builder.HasIndex(e => e.EnumValue)
                .HasDatabaseName($"IX_{DbSchemaTableNameConstants.ProfileTypeReferenceData}_EnumValue")
                .HasFilter("[EnumValue] IS NOT NULL")
                .IsUnique();
            builder.DefineIHasTimestampMutabilityRecordStateAndAuditability(ref order);
        }
    }
}
