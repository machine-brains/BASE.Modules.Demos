using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "demos_profiles");

            migrationBuilder.EnsureSchema(
                name: "demos_contributions");

            migrationBuilder.EnsureSchema(
                name: "demos_ref");

            migrationBuilder.EnsureSchema(
                name: "demos_relationships");

            migrationBuilder.CreateTable(
                name: "believer_profile",
                schema: "demos_profiles",
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
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    TraditionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Name of the religious, philosophical, or ideological tradition."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Approximate start year of active era. Negative = BCE."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Approximate end year of active era. Negative = BCE."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Believer Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Believer Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_believer_profile", x => x.Id);
                },
                comment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "believer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "contribution",
                schema: "demos_contributions",
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
                    BelieverProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Believer Profile aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of contribution. Negative = BCE."),
                    TraditionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Name of the tradition associated with this contribution."),
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of historical or cultural significance."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Contribution record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Contribution record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contribution", x => x.Id);
                },
                comment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "contributionHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "creation",
                schema: "demos_contributions",
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
                    CreatorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creator Profile aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of creation. Negative = BCE."),
                    CreativeMediumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creative Medium aggregate."),
                    Genre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Genre or sub-category within the medium."),
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of cultural or artistic significance."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Creation record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Creation record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creation", x => x.Id);
                },
                comment: "A specific creative work produced by a CreatorProfile.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creationHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "creative_medium",
                schema: "demos_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    MediaReferenceKind = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Discriminator that declares which media source field is active (None, Font, Media)."),
                    MediaFontKey = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font."),
                    MediaContentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Creative Medium Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Creative Medium Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Creative Medium Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creative_medium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_creative_medium_MediaContents_MediaContentFK",
                        column: x => x.MediaContentFK,
                        principalSchema: "sys_core",
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creative_mediumHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "creator_profile",
                schema: "demos_profiles",
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
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    CreativeMediumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creative Medium aggregate."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Approximate start year of active era. Negative = BCE."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Approximate end year of active era. Negative = BCE."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Creator Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Creator Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creator_profile", x => x.Id);
                },
                comment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creator_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "discoverer_profile",
                schema: "demos_profiles",
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
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Gets or sets the primary field of study or area of discovery."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Gets or sets the nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE)."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE)."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Discoverer Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Discoverer Profile record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discoverer_profile", x => x.Id);
                },
                comment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoverer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "discovery",
                schema: "demos_contributions",
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
                    DiscovererProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Discoverer Profile aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of discovery. Negative = BCE."),
                    LocationName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true, comment: "Name of the location where the discovery occurred."),
                    Latitude = table.Column<double>(type: "float(10)", precision: 10, scale: 7, nullable: true, comment: "Latitude coordinate of the discovery location."),
                    Longitude = table.Column<double>(type: "float(10)", precision: 10, scale: 7, nullable: true, comment: "Longitude coordinate of the discovery location."),
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of historical or scientific significance."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Discovery record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Discovery record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discovery", x => x.Id);
                },
                comment: "A specific discovery made by a DiscovererProfile.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoveryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "influence",
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
                    InfluencerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influencer Profile aggregate."),
                    InfluencerProfileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influencer Profile Type aggregate."),
                    InfluencedProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influenced Profile aggregate."),
                    InfluencedProfileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influenced Profile Type aggregate."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    InfluenceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influence Type aggregate."),
                    InfluenceStrengthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influence Strength aggregate."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Influence record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Influence record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence", x => x.Id);
                },
                comment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influenceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "influence_strength",
                schema: "demos_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    MediaReferenceKind = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Discriminator that declares which media source field is active (None, Font, Media)."),
                    MediaFontKey = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font."),
                    MediaContentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Influence Strength Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Influence Strength Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Influence Strength Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence_strength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_influence_strength_MediaContents_MediaContentFK",
                        column: x => x.MediaContentFK,
                        principalSchema: "sys_core",
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_strengthHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "influence_type",
                schema: "demos_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    MediaReferenceKind = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Discriminator that declares which media source field is active (None, Font, Media)."),
                    MediaFontKey = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font."),
                    MediaContentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Influence Type Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Influence Type Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Influence Type Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_influence_type_MediaContents_MediaContentFK",
                        column: x => x.MediaContentFK,
                        principalSchema: "sys_core",
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateTable(
                name: "profile_type",
                schema: "demos_ref",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Key = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false, comment: "Get/Set the list item's unique key."),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Get/Set whether the entity is enabled or not."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    MediaReferenceKind = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Discriminator that declares which media source field is active (None, Font, Media)."),
                    MediaFontKey = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font."),
                    MediaContentFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Profile Type Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordMutability = table.Column<int>(type: "int", nullable: false, comment: "Who/what can mutate/change the record."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    SysEndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys End Time value for the Profile Type Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodEndColumn", true),
                    SysStartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores the Sys Start Time value for the Profile Type Reference Data record.")
                        .Annotation("SqlServer:TemporalIsPeriodStartColumn", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profile_type_MediaContents_MediaContentFK",
                        column: x => x.MediaContentFK,
                        principalSchema: "sys_core",
                        principalTable: "MediaContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "profile_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.CreateIndex(
                name: "IX_believer_profile_Id",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_believer_profile_RecordState",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_BelieverProfile_PersonId",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_BelieverProfileId",
                schema: "demos_contributions",
                table: "contribution",
                column: "BelieverProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_contribution_Id",
                schema: "demos_contributions",
                table: "contribution",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contribution_RecordState",
                schema: "demos_contributions",
                table: "contribution",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_Creation_CreativeMediumId",
                schema: "demos_contributions",
                table: "creation",
                column: "CreativeMediumId");

            migrationBuilder.CreateIndex(
                name: "IX_Creation_CreatorProfileId",
                schema: "demos_contributions",
                table: "creation",
                column: "CreatorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_creation_Id",
                schema: "demos_contributions",
                table: "creation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_creation_RecordState",
                schema: "demos_contributions",
                table: "creation",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_creative_medium_EnumValue",
                schema: "demos_ref",
                table: "creative_medium",
                column: "EnumValue",
                unique: true,
                filter: "[EnumValue] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_creative_medium_Id",
                schema: "demos_ref",
                table: "creative_medium",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_creative_medium_RecordState",
                schema: "demos_ref",
                table: "creative_medium",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_Enabled",
                schema: "demos_ref",
                table: "creative_medium",
                column: "Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_FromUtc",
                schema: "demos_ref",
                table: "creative_medium",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_Key",
                schema: "demos_ref",
                table: "creative_medium",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_ToUtc",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_creator_profile_Id",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_creator_profile_RecordState",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_CreativeMediumId",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "CreativeMediumId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_PersonId",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_discoverer_profile_Id",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_discoverer_profile_RecordState",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_DiscovererProfile_PersonId",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_DiscovererProfileId",
                schema: "demos_contributions",
                table: "discovery",
                column: "DiscovererProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_discovery_Id",
                schema: "demos_contributions",
                table: "discovery",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_discovery_RecordState",
                schema: "demos_contributions",
                table: "discovery",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_influence_Id",
                schema: "demos_relationships",
                table: "influence",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluencedProfileId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluencedProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluencedProfileTypeId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluencedProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluencerProfileId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluencerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluencerProfileTypeId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluencerProfileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluenceStrengthId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluenceStrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_InfluenceTypeId",
                schema: "demos_relationships",
                table: "influence",
                column: "InfluenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_influence_RecordState",
                schema: "demos_relationships",
                table: "influence",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_influence_strength_EnumValue",
                schema: "demos_ref",
                table: "influence_strength",
                column: "EnumValue",
                unique: true,
                filter: "[EnumValue] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_influence_strength_Id",
                schema: "demos_ref",
                table: "influence_strength",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_influence_strength_RecordState",
                schema: "demos_ref",
                table: "influence_strength",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_Enabled",
                schema: "demos_ref",
                table: "influence_strength",
                column: "Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_FromUtc",
                schema: "demos_ref",
                table: "influence_strength",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_Key",
                schema: "demos_ref",
                table: "influence_strength",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_ToUtc",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_influence_type_EnumValue",
                schema: "demos_ref",
                table: "influence_type",
                column: "EnumValue",
                unique: true,
                filter: "[EnumValue] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_influence_type_Id",
                schema: "demos_ref",
                table: "influence_type",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_influence_type_RecordState",
                schema: "demos_ref",
                table: "influence_type",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_Enabled",
                schema: "demos_ref",
                table: "influence_type",
                column: "Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_FromUtc",
                schema: "demos_ref",
                table: "influence_type",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_Key",
                schema: "demos_ref",
                table: "influence_type",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_ToUtc",
                schema: "demos_ref",
                table: "influence_type",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_profile_type_EnumValue",
                schema: "demos_ref",
                table: "profile_type",
                column: "EnumValue",
                unique: true,
                filter: "[EnumValue] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_profile_type_Id",
                schema: "demos_ref",
                table: "profile_type",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profile_type_RecordState",
                schema: "demos_ref",
                table: "profile_type",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_Enabled",
                schema: "demos_ref",
                table: "profile_type",
                column: "Enabled");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_FromUtc",
                schema: "demos_ref",
                table: "profile_type",
                column: "FromUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_Key",
                schema: "demos_ref",
                table: "profile_type",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_ToUtc",
                schema: "demos_ref",
                table: "profile_type",
                column: "ToUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "believer_profile",
                schema: "demos_profiles")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "believer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "contribution",
                schema: "demos_contributions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "contributionHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "creation",
                schema: "demos_contributions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creationHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "creative_medium",
                schema: "demos_ref")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creative_mediumHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "creator_profile",
                schema: "demos_profiles")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "creator_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "discoverer_profile",
                schema: "demos_profiles")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoverer_profileHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_profiles")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "discovery",
                schema: "demos_contributions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "discoveryHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_contributions")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "influence",
                schema: "demos_relationships")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influenceHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_relationships")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "influence_strength",
                schema: "demos_ref")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_strengthHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "influence_type",
                schema: "demos_ref")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "influence_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");

            migrationBuilder.DropTable(
                name: "profile_type",
                schema: "demos_ref")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "profile_typeHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "demos_ref")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "SysEndTime")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "SysStartTime");
        }
    }
}
