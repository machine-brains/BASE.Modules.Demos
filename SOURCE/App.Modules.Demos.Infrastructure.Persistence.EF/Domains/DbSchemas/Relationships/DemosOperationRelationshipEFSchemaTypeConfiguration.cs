using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Demos.Infrastructure.Constants;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Schema;
using App.Modules.Sys.Shared.Domains.Persistence.Relational.Constants.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Modules.Demos.Infrastructure.Domains.DbSchemas.Relationships
{
    /// <summary>Fluent schema definition for explicit Demos operation relationships.</summary>
    /// <remarks>Source and target IDs remain identity-only references; the schema owns storage, not aggregate navigation.</remarks>
    public class DemosOperationRelationshipEFSchemaTypeConfiguration : IEFSchemaTypeConfiguration<DemosOperationRelationship>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<DemosOperationRelationship> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            int order = 0;
            builder.DefineTable(DbSchemaTableNameConstants.DemosOperationRelationship, DbSchemaSchemaNameConstants.Relationships);
            builder.DefineDefaultEntityBase(ref order);
            builder.DefineIHasWorkspaceFK(ref order);
            builder.DefineRequiredAggregateId(x => x.SourceExampleAId, ref order);
            builder.DefineRequiredAggregateId(x => x.TargetExampleAId, ref order);
            builder.DefineString(x => x.RelationshipKind, ref order, isRequired: true, maxLength: DefaultDbSchemaFieldSizeConstants.x128);
            builder.DefineString(x => x.Label, ref order, isRequired: true, maxLength: DefaultDbSchemaFieldSizeConstants.x256);
            builder.DefineIHasDescriptionNullable(ref order);
            builder.DefineBool(x => x.IsDirected, ref order);
            builder.DefineInt(x => x.SortOrder, ref order, isRequired: true);
        }
    }
}