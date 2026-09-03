using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using App.Modules.Sys.Shared.Domains.Persistence.Relational.Constants.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Contributions
{
    /// <summary>
    /// EF Core schema configuration for <see cref="Contribution"/>.
    /// </summary>
    public class ContributionEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<Contribution>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Contribution> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.Contribution, DbSchemaSchemaNameConstants.Contributions);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineRequiredAggregateId(x => x.BelieverProfileId, ref order);
            builder.DefineIHasTitle(ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineInt(x => x.Year, ref order);
            builder.DefineString(x => x.TraditionName, ref order, isRequired: false, maxLength: DefaultDbSchemaFieldSizeConstants.x256);
            builder.DefineString(x => x.Significance, ref order, isRequired: false, maxLength: null, optionalColumnType: "nvarchar(max)");
        }
    }
}
