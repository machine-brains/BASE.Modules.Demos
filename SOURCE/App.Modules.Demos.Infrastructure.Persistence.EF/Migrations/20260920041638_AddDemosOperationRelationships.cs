using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDemosOperationRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operation_relationship",
                schema: "demos_relationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    WorkspaceFK = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The FK of the related Workspace."),
                    SourceExampleAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Source Example A aggregate."),
                    TargetExampleAId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Target Example A aggregate."),
                    RelationshipKind = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "Gets or sets the domain-owned relationship kind."),
                    Label = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Gets or sets the human-readable relationship label."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    IsDirected = table.Column<bool>(type: "bit", nullable: false, comment: "Gets or sets whether the edge has a source-to-target direction."),
                    SortOrder = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the stable display order among related edges."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Demos Operation Relationship record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Demos Operation Relationship record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_relationship", x => x.Id);
                },
                comment: "Explicit peer relationship between two Demos ExampleA operation records.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "operation_relationshipHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateIndex(
                name: "IX_DemosOperationRelationship_SourceExampleAId",
                schema: "demos_relationships",
                table: "operation_relationship",
                column: "SourceExampleAId");

            migrationBuilder.CreateIndex(
                name: "IX_DemosOperationRelationship_TargetExampleAId",
                schema: "demos_relationships",
                table: "operation_relationship",
                column: "TargetExampleAId");

            migrationBuilder.CreateIndex(
                name: "IX_DemosOperationRelationship_WorkspaceFK",
                schema: "demos_relationships",
                table: "operation_relationship",
                column: "WorkspaceFK");

            migrationBuilder.CreateIndex(
                name: "IX_operation_relationship_Id",
                schema: "demos_relationships",
                table: "operation_relationship",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_operation_relationship_RecordState",
                schema: "demos_relationships",
                table: "operation_relationship",
                column: "RecordState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operation_relationship",
                schema: "demos_relationships")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "operation_relationshipHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");
        }
    }
}
