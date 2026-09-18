using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExamplesTemporalSpatialCapabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FromUtc",
                schema: "demos_examples",
                table: "example_b",
                type: "datetimeoffset",
                nullable: true,
                comment: "Gets or sets the start datetime.")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                schema: "demos_examples",
                table: "example_b",
                type: "float(10)",
                precision: 10,
                scale: 7,
                nullable: true,
                comment: "Optional WGS84 latitude in degrees.")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                schema: "demos_examples",
                table: "example_b",
                type: "float(10)",
                precision: 10,
                scale: 7,
                nullable: true,
                comment: "Optional WGS84 longitude in degrees.")
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ToUtc",
                schema: "demos_examples",
                table: "example_b",
                type: "datetimeoffset",
                nullable: true,
                comment: "Gets or sets the end datetime.")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FromUtc",
                schema: "demos_examples",
                table: "example_a",
                type: "datetimeoffset",
                nullable: true,
                comment: "Gets or sets the start datetime.")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                schema: "demos_examples",
                table: "example_a",
                type: "float(10)",
                precision: 10,
                scale: 7,
                nullable: true,
                comment: "Optional WGS84 latitude in degrees.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                schema: "demos_examples",
                table: "example_a",
                type: "float(10)",
                precision: 10,
                scale: 7,
                nullable: true,
                comment: "Optional WGS84 longitude in degrees.")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ToUtc",
                schema: "demos_examples",
                table: "example_a",
                type: "datetimeoffset",
                nullable: true,
                comment: "Gets or sets the end datetime.")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [FromUtc] = '2026-09-15T09:00:00+00:00', [ToUtc] = '2026-09-15T10:30:00+00:00', [Latitude] = -41.2866, [Longitude] = 174.7756 " +
                "WHERE [Id] = '70000001-0001-0001-0001-000000000001';");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [FromUtc] = '2026-09-16T11:00:00+00:00', [ToUtc] = '2026-09-16T12:00:00+00:00', [Latitude] = -36.8485, [Longitude] = 174.7633 " +
                "WHERE [Id] = '70000001-0001-0001-0001-000000000002';");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_b] " +
                "SET [FromUtc] = '2026-09-15T09:15:00+00:00', [ToUtc] = '2026-09-15T09:45:00+00:00', [Latitude] = -41.2924, [Longitude] = 174.7787 " +
                "WHERE [Id] = '70000002-0002-0002-0002-000000000001';");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_b] " +
                "SET [FromUtc] = '2026-09-16T11:15:00+00:00', [ToUtc] = '2026-09-16T11:45:00+00:00', [Latitude] = -36.8529, [Longitude] = 174.7681 " +
                "WHERE [Id] = '70000002-0002-0002-0002-000000000002';");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_FromUtc",
                schema: "demos_examples",
                table: "example_b",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleB_ToUtc",
                schema: "demos_examples",
                table: "example_b",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_FromUtc",
                schema: "demos_examples",
                table: "example_a",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleA_ToUtc",
                schema: "demos_examples",
                table: "example_a",
                column: "ToUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExampleB_FromUtc",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropIndex(
                name: "IX_ExampleB_ToUtc",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropIndex(
                name: "IX_ExampleA_FromUtc",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropIndex(
                name: "IX_ExampleA_ToUtc",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropColumn(
                name: "FromUtc",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropColumn(
                name: "ToUtc",
                schema: "demos_examples",
                table: "example_b");

            migrationBuilder.DropColumn(
                name: "FromUtc",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "demos_examples",
                table: "example_a");

            migrationBuilder.DropColumn(
                name: "ToUtc",
                schema: "demos_examples",
                table: "example_a");

        }
    }
}
