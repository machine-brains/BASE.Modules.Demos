using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class FixMediaContentSharedTableOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creative_medium_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_strength_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_type_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_type_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "profile_type");

            // Data cleanup: existing ImageFK values were populated against this module's own
            // now-retired local MediaContent table copy. Those ids do not exist in the canonical
            // sys_core.MediaContents table, so re-pointing the FK below would violate referential
            // integrity. Null out any orphaned references before re-adding the FK. There are no
            // consumers yet, so resetting a broken image reference is safe.
            migrationBuilder.Sql(@"
UPDATE [demos_ref].[creative_medium] SET [ImageFK] = NULL WHERE [ImageFK] IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [sys_core].[MediaContents] mc WHERE mc.[Id] = [creative_medium].[ImageFK]);
UPDATE [demos_ref].[influence_strength] SET [ImageFK] = NULL WHERE [ImageFK] IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [sys_core].[MediaContents] mc WHERE mc.[Id] = [influence_strength].[ImageFK]);
UPDATE [demos_ref].[influence_type] SET [ImageFK] = NULL WHERE [ImageFK] IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [sys_core].[MediaContents] mc WHERE mc.[Id] = [influence_type].[ImageFK]);
UPDATE [demos_ref].[profile_type] SET [ImageFK] = NULL WHERE [ImageFK] IS NOT NULL AND NOT EXISTS (SELECT 1 FROM [sys_core].[MediaContents] mc WHERE mc.[Id] = [profile_type].[ImageFK]);
");

            migrationBuilder.AddForeignKey(
                name: "FK_creative_medium_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_strength_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_type_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_type_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creative_medium_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_strength_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_type_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_type_MediaContents_ImageFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.EnsureSchema(
                name: "demos");

            migrationBuilder.AddForeignKey(
                name: "FK_creative_medium_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageFK",
                principalSchema: "demos",
                principalTable: "MediaContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_strength_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageFK",
                principalSchema: "demos",
                principalTable: "MediaContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_type_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageFK",
                principalSchema: "demos",
                principalTable: "MediaContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_type_MediaContent_ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageFK",
                principalSchema: "demos",
                principalTable: "MediaContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
