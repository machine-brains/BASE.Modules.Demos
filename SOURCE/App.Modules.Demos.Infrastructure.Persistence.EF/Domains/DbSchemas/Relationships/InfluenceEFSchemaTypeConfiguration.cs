using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Relationships
{
    /// <summary>
    /// EF Core schema configuration for <see cref="Influence"/>.
    /// </summary>
    public class InfluenceEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<Influence>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Influence> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;

            builder.DefineTable(DbSchemaTableNameConstants.Influence, DbSchemaSchemaNameConstants.Relationships);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineRequiredAggregateId(x => x.InfluencerProfileId, ref order);
            builder.DefineRequiredAggregateId(x => x.InfluencerProfileTypeId, ref order);
            builder.DefineRequiredAggregateId(x => x.InfluencedProfileId, ref order);
            builder.DefineRequiredAggregateId(x => x.InfluencedProfileTypeId, ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineRequiredAggregateId(x => x.InfluenceTypeId, ref order);
            builder.DefineRequiredAggregateId(x => x.InfluenceStrengthId, ref order);
        }
    }
}

