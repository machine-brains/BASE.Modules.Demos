using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Configuration.Profiles
{
    /// <summary>
    /// EF Core schema configuration for <see cref="CreatorProfile"/>.
    /// </summary>
    public class CreatorProfileConfiguration : IEFSchemaTypeConfiguration<CreatorProfile>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<CreatorProfile> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.CreatorProfile, DbSchemaSchemaNameConstants.Profiles);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineRequiredAggregateId(x => x.PersonId, ref order);
            builder.DefineIHasTitle(ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineRequiredAggregateId(x => x.CreativeMediumId, ref order);
            builder.DefineString(x => x.Nationality, ref order, isRequired: false, maxLength: 256);
            builder.DefineInt(x => x.EraFrom, ref order, isRequired: false);
            builder.DefineInt(x => x.EraTo, ref order, isRequired: false);
        }
    }
}

