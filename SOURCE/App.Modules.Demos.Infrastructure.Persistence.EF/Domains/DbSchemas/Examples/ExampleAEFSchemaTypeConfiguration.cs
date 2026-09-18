using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Examples
{
    /// <summary>Fluent schema definition for the Demos ExampleA parent entity.</summary>
    /// <remarks>All columns use BASE schema extensions so ordering and persistence metadata remain platform-owned.</remarks>
    public class ExampleAEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<ExampleA>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<ExampleA> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;
            builder.DefineTable(DbSchemaTableNameConstants.ExampleA, DbSchemaSchemaNameConstants.Examples);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineIHasWorkspaceFK(ref order);
            builder.DefineIHasFromToUtcNullable(ref order);
            builder.DefineIHasTitleAndDescription(ref order);
            builder.DefineDouble(x => x.Latitude, ref order, isRequired: false, optionalComment: "Optional WGS84 latitude in degrees.");
            builder.DefineDouble(x => x.Longitude, ref order, isRequired: false, optionalComment: "Optional WGS84 longitude in degrees.");
            builder.DefineBool(x => x.IsActive, ref order);
        }
    }
}