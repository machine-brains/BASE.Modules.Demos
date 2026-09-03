using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using App.Modules.Sys.Shared.Domains.Persistence.Relational.Constants.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Contributions
{
    /// <summary>
    /// EF Core schema configuration for <see cref="Creation"/>.
    /// </summary>
    public class CreationEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<Creation>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Creation> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.Creation, DbSchemaSchemaNameConstants.Contributions);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineRequiredAggregateId(x => x.CreatorProfileId, ref order);
            builder.DefineIHasTitle(ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineInt(x => x.Year, ref order);
            builder.DefineRequiredAggregateId(x => x.CreativeMediumId, ref order);
            builder.DefineString(x => x.Genre, ref order, isRequired: false, maxLength: DefaultDbSchemaFieldSizeConstants.x256);
            builder.DefineString(x => x.Significance, ref order, isRequired: false, maxLength: null, optionalColumnType: "nvarchar(max)");
        }
    }
}

