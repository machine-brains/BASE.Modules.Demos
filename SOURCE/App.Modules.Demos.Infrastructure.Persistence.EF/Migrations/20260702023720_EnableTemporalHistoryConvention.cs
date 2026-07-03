using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class EnableTemporalHistoryConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "profile_type",
                schema: "demos_ref",
                comment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "profile_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence_type",
                schema: "demos_ref",
                comment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence_strength",
                schema: "demos_ref",
                comment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_strengthHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence",
                schema: "demos_relationships",
                comment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.",
                oldComment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influenceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "discovery",
                schema: "demos_contributions",
                comment: "A specific discovery made by a DiscovererProfile.",
                oldComment: "A specific discovery made by a DiscovererProfile.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoveryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "discoverer_profile",
                schema: "demos_profiles",
                comment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.",
                oldComment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoverer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creator_profile",
                schema: "demos_profiles",
                comment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.",
                oldComment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creator_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creative_medium",
                schema: "demos_ref",
                comment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creative_mediumHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creation",
                schema: "demos_contributions",
                comment: "A specific creative work produced by a CreatorProfile.",
                oldComment: "A specific creative work produced by a CreatorProfile.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creationHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "contribution",
                schema: "demos_contributions",
                comment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.",
                oldComment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "contributionHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "believer_profile",
                schema: "demos_profiles",
                comment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.",
                oldComment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "believer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "profile_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Profile Type Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "profile_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Profile Type Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "influence_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Influence Type Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "influence_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Influence Type Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "influence_strength",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Influence Strength Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "influence_strength",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Influence Strength Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_relationships",
                table: "influence",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Influence record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_relationships",
                table: "influence",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Influence record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "discovery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Discovery record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "discovery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Discovery record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Discoverer Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Discoverer Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Creator Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Creator Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "creative_medium",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Creative Medium Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "creative_medium",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Creative Medium Reference Data record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "creation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Creation record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "creation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Creation record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "contribution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Contribution record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "contribution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Contribution record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys End Time value for the Believer Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores the Sys Start Time value for the Believer Profile record.")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "profile_type")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "profile_type")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "influence_type")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "influence_type")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "influence_strength")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "influence_strength")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_relationships",
                table: "influence")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_relationships",
                table: "influence")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "discovery")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "discovery")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "discoverer_profile")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "discoverer_profile")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "creator_profile")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "creator_profile")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_ref",
                table: "creative_medium")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_ref",
                table: "creative_medium")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "creation")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "creation")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_contributions",
                table: "contribution")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_contributions",
                table: "contribution")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.DropColumn(
                name: "SysEndTime",
                schema: "demos_profiles",
                table: "believer_profile")
                .Annotation("SqlServer:TemporalIsPeriodEndColumn", true);

            migrationBuilder.DropColumn(
                name: "SysStartTime",
                schema: "demos_profiles",
                table: "believer_profile")
                .Annotation("SqlServer:TemporalIsPeriodStartColumn", true);

            migrationBuilder.AlterTable(
                name: "profile_type",
                schema: "demos_ref",
                comment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "profile_typeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence_type",
                schema: "demos_ref",
                comment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "influence_typeHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence_strength",
                schema: "demos_ref",
                comment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "influence_strengthHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "influence",
                schema: "demos_relationships",
                comment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.",
                oldComment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "influenceHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "discovery",
                schema: "demos_contributions",
                comment: "A specific discovery made by a DiscovererProfile.",
                oldComment: "A specific discovery made by a DiscovererProfile.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "discoveryHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "discoverer_profile",
                schema: "demos_profiles",
                comment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.",
                oldComment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "discoverer_profileHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creator_profile",
                schema: "demos_profiles",
                comment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.",
                oldComment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "creator_profileHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creative_medium",
                schema: "demos_ref",
                comment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.",
                oldComment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "creative_mediumHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "creation",
                schema: "demos_contributions",
                comment: "A specific creative work produced by a CreatorProfile.",
                oldComment: "A specific creative work produced by a CreatorProfile.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "creationHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "contribution",
                schema: "demos_contributions",
                comment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.",
                oldComment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "contributionHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.AlterTable(
                name: "believer_profile",
                schema: "demos_profiles",
                comment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.",
                oldComment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "believer_profileHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");
        }
    }
}
