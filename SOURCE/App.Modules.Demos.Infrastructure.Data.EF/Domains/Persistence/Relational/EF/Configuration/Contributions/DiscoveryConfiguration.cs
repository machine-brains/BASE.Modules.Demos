using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Configuration.Contributions
{
    /// <summary>
    /// EF Core schema configuration for <see cref="Discovery"/>.
    /// </summary>
    public class DiscoveryConfiguration : IEFSchemaTypeConfiguration<Discovery>
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
            builder.DefineString(x => x.LocationName, ref order, isRequired: false, maxLength: 512);
            builder.DefineDouble(x => x.Latitude, ref order, isRequired: false);
            builder.DefineDouble(x => x.Longitude, ref order, isRequired: false);
            builder.DefineString(x => x.Significance, ref order, isRequired: false, maxLength: 0);
        }
    }
}
