using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageDescriptionFromEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "creative_medium");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "profile_type",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Accessible description of the associated image (rendered as the HTML alt attribute or equivalent ARIA label by the UI layer).")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "influence_type",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Accessible description of the associated image (rendered as the HTML alt attribute or equivalent ARIA label by the UI layer).")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "influence_strength",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Accessible description of the associated image (rendered as the HTML alt attribute or equivalent ARIA label by the UI layer).")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                schema: "demos_ref",
                table: "creative_medium",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Accessible description of the associated image (rendered as the HTML alt attribute or equivalent ARIA label by the UI layer).")
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageDescription",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageDescription",
                value: null);
        }
    }
}
