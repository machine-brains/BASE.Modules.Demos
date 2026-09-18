using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Examples
{
    /// <summary>Fluent schema definition for ordered Demos ExampleB child records.</summary>
    /// <remarks>ExampleAId is a governed aggregate identifier rather than a raw EF relationship.</remarks>
    public class ExampleBEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<ExampleB>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ExampleB> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;
            builder.DefineTable(DbSchemaTableNameConstants.ExampleB, DbSchemaSchemaNameConstants.Examples);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineIHasWorkspaceFK(ref order);
            builder.DefineIHasFromToUtcNullable(ref order);
            builder.DefineRequiredAggregateId(
                x => x.ExampleAId,
                ref order,
                optionalIndexName: "IX_example_b_example_a_id");
            builder.DefineIHasName(ref order);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineDouble(x => x.Latitude, ref order, isRequired: false, optionalComment: "Optional WGS84 latitude in degrees.");
            builder.DefineDouble(x => x.Longitude, ref order, isRequired: false, optionalComment: "Optional WGS84 longitude in degrees.");
            builder.DefineInt(x => x.SortOrder, ref order, isRequired: true);
        }
    }
}