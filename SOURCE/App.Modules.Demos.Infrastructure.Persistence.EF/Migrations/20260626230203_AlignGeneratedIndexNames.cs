using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class AlignGeneratedIndexNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_ProfileTypeReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_profile_type_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileTypeReferenceData_RecordState",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_profile_type_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileTypeReferenceData_Id",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_profile_type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceTypeReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_influence_type_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceTypeReferenceData_RecordState",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_influence_type_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceTypeReferenceData_Id",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_influence_type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceStrengthReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_influence_strength_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceStrengthReferenceData_RecordState",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_influence_strength_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_InfluenceStrengthReferenceData_Id",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_influence_strength_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Influence_RecordState",
                schema: "demos_relationships",
                table: "influence",
                newName: "IX_influence_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_Influence_Id",
                schema: "demos_relationships",
                table: "influence",
                newName: "IX_influence_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Discovery_RecordState",
                schema: "demos_contributions",
                table: "discovery",
                newName: "IX_discovery_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_Discovery_Id",
                schema: "demos_contributions",
                table: "discovery",
                newName: "IX_discovery_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DiscovererProfile_RecordState",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "IX_discoverer_profile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_DiscovererProfile_Id",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "IX_discoverer_profile_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CreatorProfile_RecordState",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "IX_creator_profile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_CreatorProfile_Id",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "IX_creator_profile_Id");

            migrationBuilder.RenameIndex(
                name: "IX_CreativeMediumReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_creative_medium_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_CreativeMediumReferenceData_RecordState",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_creative_medium_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_CreativeMediumReferenceData_Id",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_creative_medium_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Creation_RecordState",
                schema: "demos_contributions",
                table: "creation",
                newName: "IX_creation_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_Creation_Id",
                schema: "demos_contributions",
                table: "creation",
                newName: "IX_creation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_RecordState",
                schema: "demos_contributions",
                table: "contribution",
                newName: "IX_contribution_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_Id",
                schema: "demos_contributions",
                table: "contribution",
                newName: "IX_contribution_Id");

            migrationBuilder.RenameIndex(
                name: "IX_BelieverProfile_RecordState",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "IX_believer_profile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_BelieverProfile_Id",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "IX_believer_profile_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_profile_type_ReferenceDataType",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_ProfileTypeReferenceData_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_profile_type_RecordState",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_ProfileTypeReferenceData_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_profile_type_Id",
                schema: "demos_ref",
                table: "profile_type",
                newName: "IX_ProfileTypeReferenceData_Id");

            migrationBuilder.RenameIndex(
                name: "IX_influence_type_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_InfluenceTypeReferenceData_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_influence_type_RecordState",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_InfluenceTypeReferenceData_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_influence_type_Id",
                schema: "demos_ref",
                table: "influence_type",
                newName: "IX_InfluenceTypeReferenceData_Id");

            migrationBuilder.RenameIndex(
                name: "IX_influence_strength_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_InfluenceStrengthReferenceData_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_influence_strength_RecordState",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_InfluenceStrengthReferenceData_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_influence_strength_Id",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "IX_InfluenceStrengthReferenceData_Id");

            migrationBuilder.RenameIndex(
                name: "IX_influence_RecordState",
                schema: "demos_relationships",
                table: "influence",
                newName: "IX_Influence_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_influence_Id",
                schema: "demos_relationships",
                table: "influence",
                newName: "IX_Influence_Id");

            migrationBuilder.RenameIndex(
                name: "IX_discovery_RecordState",
                schema: "demos_contributions",
                table: "discovery",
                newName: "IX_Discovery_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_discovery_Id",
                schema: "demos_contributions",
                table: "discovery",
                newName: "IX_Discovery_Id");

            migrationBuilder.RenameIndex(
                name: "IX_discoverer_profile_RecordState",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "IX_DiscovererProfile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_discoverer_profile_Id",
                schema: "demos_profiles",
                table: "discoverer_profile",
                newName: "IX_DiscovererProfile_Id");

            migrationBuilder.RenameIndex(
                name: "IX_creator_profile_RecordState",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "IX_CreatorProfile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_creator_profile_Id",
                schema: "demos_profiles",
                table: "creator_profile",
                newName: "IX_CreatorProfile_Id");

            migrationBuilder.RenameIndex(
                name: "IX_creative_medium_ReferenceDataType",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_CreativeMediumReferenceData_ReferenceDataType");

            migrationBuilder.RenameIndex(
                name: "IX_creative_medium_RecordState",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_CreativeMediumReferenceData_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_creative_medium_Id",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "IX_CreativeMediumReferenceData_Id");

            migrationBuilder.RenameIndex(
                name: "IX_creation_RecordState",
                schema: "demos_contributions",
                table: "creation",
                newName: "IX_Creation_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_creation_Id",
                schema: "demos_contributions",
                table: "creation",
                newName: "IX_Creation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_contribution_RecordState",
                schema: "demos_contributions",
                table: "contribution",
                newName: "IX_Contribution_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_contribution_Id",
                schema: "demos_contributions",
                table: "contribution",
                newName: "IX_Contribution_Id");

            migrationBuilder.RenameIndex(
                name: "IX_believer_profile_RecordState",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "IX_BelieverProfile_RecordState");

            migrationBuilder.RenameIndex(
                name: "IX_believer_profile_Id",
                schema: "demos_profiles",
                table: "believer_profile",
                newName: "IX_BelieverProfile_Id");
        }
    }
}
