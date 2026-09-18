using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScopeExamplesForWorkspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                schema: "demos_examples",
                table: "example_b",
                type: "int",
                nullable: false,
                comment: "Gets or sets the deterministic display order within the parent.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Gets or sets the deterministic display order within the parent.")
                .Annotation("Relational:ColumnOrder", 14)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "demos_examples",
                table: "example_b",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "The name of the model.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "The name of the model.")
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExampleAId",
                schema: "demos_examples",
                table: "example_b",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Opaque identifier for the related Example A aggregate.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Opaque identifier for the related Example A aggregate.")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "demos_examples",
                table: "example_b",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                comment: "The textual Description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldComment: "The textual Description.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkspaceFK",
                schema: "demos_examples",
                table: "example_b",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The FK of the related Workspace.")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "demos_examples",
                table: "example_a",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "The (display) title.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "The (display) title.")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "demos_examples",
                table: "example_a",
                type: "bit",
                nullable: false,
                comment: "Gets or sets whether this example is active.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Gets or sets whether this example is active.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "demos_examples",
                table: "example_a",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                comment: "The textual Description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldComment: "The textual Description.")
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkspaceFK",
                schema: "demos_examples",
                table: "example_a",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The FK of the related Workspace.")
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "WHERE [Id] IN ('70000001-0001-0001-0001-000000000001', '70000001-0001-0001-0001-000000000002');");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_b] " +
                "SET [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "WHERE [Id] IN ('70000002-0002-0002-0002-000000000001', '70000002-0002-0002-0002-000000000002');");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_WorkspaceFK",
                schema: "demos_examples",
                table: "example_b",
                column: "WorkspaceFK");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_WorkspaceFK",
                schema: "demos_examples",
                table: "example_a",
                column: "WorkspaceFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExampleB_WorkspaceFK",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropIndex(
                name: "IX_ExampleA_WorkspaceFK",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropColumn(
                name: "WorkspaceFK",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropColumn(
                name: "WorkspaceFK",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                schema: "demos_examples",
                table: "example_b",
                type: "int",
                nullable: false,
                comment: "Gets or sets the deterministic display order within the parent.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Gets or sets the deterministic display order within the parent.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "demos_examples",
                table: "example_b",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "The name of the model.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "The name of the model.")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExampleAId",
                schema: "demos_examples",
                table: "example_b",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Opaque identifier for the related Example A aggregate.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Opaque identifier for the related Example A aggregate.")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "demos_examples",
                table: "example_b",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                comment: "The textual Description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldComment: "The textual Description.")
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "demos_examples",
                table: "example_a",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "The (display) title.",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "The (display) title.")
                .Annotation("Relational:ColumnOrder", 10)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "demos_examples",
                table: "example_a",
                type: "bit",
                nullable: false,
                comment: "Gets or sets whether this example is active.",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Gets or sets whether this example is active.")
                .Annotation("Relational:ColumnOrder", 12)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "demos_examples",
                table: "example_a",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                comment: "The textual Description.",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true,
                oldComment: "The textual Description.")
                .Annotation("Relational:ColumnOrder", 11)
                .OldAnnotation("Relational:ColumnOrder", 12);
        }
    }
}
