using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelDrift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_ref",
                table: "profile_type",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_ref",
                table: "profile_type",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_ref",
                table: "influence_type",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_ref",
                table: "influence_type",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_relationships",
                table: "influence",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_relationships",
                table: "influence",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "discovery",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "discovery",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "creation",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "creation",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "contribution",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_contributions",
                table: "contribution",
                newName: "CreatedOnUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "LastModifiedOnUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnDateTimeUtc",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "CreatedOnUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_ref",
                table: "profile_type",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_ref",
                table: "profile_type",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_ref",
                table: "influence_type",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_ref",
                table: "influence_type",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_relationships",
                table: "influence",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_relationships",
                table: "influence",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_contributions",
                table: "discovery",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_contributions",
                table: "discovery",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_contributions",
                table: "creation",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_contributions",
                table: "creation",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_contributions",
                table: "contribution",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_contributions",
                table: "contribution",
                newName: "CreatedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "LastModifiedOnUtc",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "LastModifiedOnDateTimeUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUtc",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "CreatedOnDateTimeUtc");
        }
    }
}
