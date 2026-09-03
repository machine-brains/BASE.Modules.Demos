using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using App.Modules.Sys.Shared.Domains.Persistence.Relational.Constants.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Contributions
{
    /// <summary>
    /// EF Core schema configuration for <see cref="Discovery"/>.
    /// </summary>
    public class DiscoveryEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<Discovery>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Discovery> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.Discovery, DbSchemaSchemaNameConstants.Contributions);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineRequiredAggregateId(x => x.DiscovererProfileId, ref order);
            builder.DefineIHasTitle(ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineInt(x => x.Year, ref order);
            builder.DefineString(x => x.LocationName, ref order, isRequired: false, maxLength: DefaultDbSchemaFieldSizeConstants.x512);
            builder.DefineDouble(x => x.Latitude, ref order, isRequired: false);
            builder.DefineDouble(x => x.Longitude, ref order, isRequired: false);
            builder.DefineString(x => x.Significance, ref order, isRequired: false, maxLength: null, optionalColumnType: "nvarchar(max)");
        }
    }
}
