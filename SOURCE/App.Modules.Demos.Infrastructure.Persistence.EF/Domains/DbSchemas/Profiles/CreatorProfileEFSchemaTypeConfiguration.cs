using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using App.Modules.Sys.Shared.Domains.Persistence.Relational.Constants.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Profiles
{
    /// <summary>
    /// EF Core schema configuration for <see cref="CreatorProfile"/>.
    /// </summary>
    public class CreatorProfileEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<CreatorProfile>
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
            builder.DefineString(x => x.Nationality, ref order, isRequired: false, maxLength: DefaultDbSchemaFieldSizeConstants.x256);
            builder.DefineInt(x => x.EraFrom, ref order, isRequired: false);
            builder.DefineInt(x => x.EraTo, ref order, isRequired: false);
        }
    }
}

