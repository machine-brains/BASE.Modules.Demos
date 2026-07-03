using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
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

            migrationBuilder.EnsureSchema(
                name: "demos");

            migrationBuilder.CreateTable(
                name: "believer_profile",
                schema: "demos_profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    TraditionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Name of the religious, philosophical, or ideological tradition."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Approximate start year of active era. Negative = BCE."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Approximate end year of active era. Negative = BCE.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_believer_profile", x => x.Id);
                },
                comment: "Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.");

            migrationBuilder.CreateTable(
                name: "contribution",
                schema: "demos_contributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    BelieverProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Believer Profile aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of contribution. Negative = BCE."),
                    TraditionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Name of the tradition associated with this contribution."),
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of historical or cultural significance.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contribution", x => x.Id);
                },
                comment: "A specific contribution made by a BelieverProfile. Captures the act of faith, philosophical insight, or ideological initiative and its significance.");

            migrationBuilder.CreateTable(
                name: "creation",
                schema: "demos_contributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    CreatorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creator Profile aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of creation. Negative = BCE."),
                    CreativeMediumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creative Medium aggregate."),
                    Genre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Genre or sub-category within the medium."),
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of cultural or artistic significance.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creation", x => x.Id);
                },
                comment: "A specific creative work produced by a CreatorProfile.");

            migrationBuilder.CreateTable(
                name: "creator_profile",
                schema: "demos_profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    CreativeMediumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Creative Medium aggregate."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Approximate start year of active era. Negative = BCE."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Approximate end year of active era. Negative = BCE.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creator_profile", x => x.Id);
                },
                comment: "Creator profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.");

            migrationBuilder.CreateTable(
                name: "discoverer_profile",
                schema: "demos_profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Person aggregate."),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false, comment: "The (display) title."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Gets or sets the primary field of study or area of discovery."),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Gets or sets the nationality or cultural origin."),
                    EraFrom = table.Column<int>(type: "int", nullable: true, comment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE)."),
                    EraTo = table.Column<int>(type: "int", nullable: true, comment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discoverer_profile", x => x.Id);
                },
                comment: "Represents a Discoverer profile — one who expands the boundaries of knowledge through exploration and inquiry, as described in Daniel J. Boorstin's The Discoverers.");

            migrationBuilder.CreateTable(
                name: "discovery",
                schema: "demos_contributions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
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
                    Significance = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Statement of historical or scientific significance.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discovery", x => x.Id);
                },
                comment: "A specific discovery made by a DiscovererProfile.");

            migrationBuilder.CreateTable(
                name: "influence",
                schema: "demos_relationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Gets or sets the identifier."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable)."),
                    InfluencerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influencer Profile aggregate."),
                    InfluencerProfileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influencer Profile Type aggregate."),
                    InfluencedProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influenced Profile aggregate."),
                    InfluencedProfileTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influenced Profile Type aggregate."),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "The textual Description."),
                    InfluenceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influence Type aggregate."),
                    InfluenceStrengthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Opaque identifier for the related Influence Strength aggregate.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence", x => x.Id);
                },
                comment: "Directional influence relationship between two historical profiles. Captures who influenced whom, the nature of that influence, and its strength. Both profile references are opaque boundary FKs — no navigation properties.");

            migrationBuilder.CreateTable(
                name: "MediaContent",
                schema: "demos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key for the Media Content record."),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Logical content key used to group culture variants together. Example: \"terms_md\", \"logo_png\"."),
                    BlobPath = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The blob path for the default (culture-neutral) content, including the container prefix (e.g. \"media-signed/agreements/agreements/{guid}.md\")."),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "MIME type of the content (e.g. \"text/markdown\", \"text/plain\", \"image/png\"). and custom ones: \"font\"\"font/woff2\"\"font/ttf\""),
                    ContentHash = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "SHA-256 hash of the default content at import/publish time."),
                    ContentHashAlgorithm = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The hash algorithm used (e.g. \"SHA-256\")."),
                    ContentSizeBytes = table.Column<long>(type: "bigint", nullable: true, comment: "Size of the blob content in bytes. Used to populate Content-Length headers for downloads, display file-size hints in the UI, and support accessible media descriptions. Null until the blob has been written and its size confirmed."),
                    WidthPx = table.Column<int>(type: "int", nullable: true, comment: "Width of the image in pixels. Only populated for image media types (e.g. image/png, image/jpeg, image/webp). Null for non-image content. Used for aspect-ratio preservation during resize operations and to emit width / height HTML attributes that prevent cumulative layout shift (CLS)."),
                    HeightPx = table.Column<int>(type: "int", nullable: true, comment: "Height of the image in pixels. See for full context."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp. Note that this is filled in when persisted in the db -- so it's usable to determine whether Record is New or not."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on. Changed To DateTimeOffset."),
                    CreatedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete). Null until a state transition (soft delete, archive, etc.) occurs."),
                    StateChangedByPrincipalId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContent", x => x.Id);
                },
                comment: "Concrete entity for culture-neutral media content. See for full documentation.");

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
                    ImageFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to the MediaContent record representing the image. Null when no image is assigned."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    ReferenceDataType = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the reference data classification."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Creative Medium Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creative_medium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_creative_medium_MediaContent_ImageFK",
                        column: x => x.ImageFK,
                        principalSchema: "demos",
                        principalTable: "MediaContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing a creative medium (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display medium labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.");

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
                    ImageFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to the MediaContent record representing the image. Null when no image is assigned."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    ReferenceDataType = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the reference data classification."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Influence Strength Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence_strength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_influence_strength_MediaContent_ImageFK",
                        column: x => x.ImageFK,
                        principalSchema: "demos",
                        principalTable: "MediaContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing the magnitude of an influence relationship (Minor, Moderate, Major, Transformative). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display strength labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.");

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
                    ImageFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to the MediaContent record representing the image. Null when no image is assigned."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    ReferenceDataType = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the reference data classification."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Influence Type Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_influence_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_influence_type_MediaContent_ImageFK",
                        column: x => x.ImageFK,
                        principalSchema: "demos",
                        principalTable: "MediaContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing the nature of an influence relationship (Direct, Indirect, Intellectual, Spiritual, Artistic, Scientific, Philosophical). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display influence type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.");

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
                    ImageFK = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "FK to the MediaContent record representing the image. Null when no image is assigned."),
                    DisplayStyleHint = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "A Hint on how to display the item. Consider using the field for a Classname that will mean something to the UX interface."),
                    DisplayOrderHint = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "A Hint to the Interface (UI/API) to organise item order on initial display. Non-unique. May be overridden by MRU settings."),
                    ReferenceDataType = table.Column<int>(type: "int", nullable: false, comment: "Gets or sets the reference data classification."),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Stores the Value value for the Profile Type Reference Data record."),
                    FromUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the start datetime."),
                    ToUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the end datetime."),
                    EnumValue = table.Column<int>(type: "int", nullable: true, comment: "The integer value from the enum. For system-seeded records, this matches the enum value exactly."),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false, comment: "Gets or sets the datastore concurrency check timestamp."),
                    RecordState = table.Column<int>(type: "int", nullable: false, comment: "The state of the Record in terms of persistence."),
                    CreatedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime created on."),
                    CreatedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who created the record."),
                    LastModifiedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Gets or sets the UTC DateTime when the record was last modified."),
                    LastModifiedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false, comment: "Gets or sets the principal id who last modified the record."),
                    StateChangedOnDateTimeUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "Gets or sets the date when record state changed (nullable for soft delete)."),
                    StateChangedByPrincipalId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true, comment: "Gets or sets the principal id who changed the state (nullable).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profile_type_MediaContent_ImageFK",
                        column: x => x.ImageFK,
                        principalSchema: "demos",
                        principalTable: "MediaContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                },
                comment: "Reference data entity representing a profile type within the Boorstin Trilogy classification (Discoverer, Creator, Believer). Converts the enum into a reference data table so that referential integrity can be enforced at the database level and UX can display profile type labels dynamically. Deterministic GUIDs: System-seeded entries use GUIDs derived from the enum integer value via DeterministicGuid.FromEnum.");

            migrationBuilder.InsertData(
                schema: "demos_profiles",
                table: "believer_profile",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "EraFrom", "EraTo", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "Nationality", "PersonId", "RecordState", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "TraditionName" },
                values: new object[,]
                {
                    { new Guid("10000003-0003-0003-0003-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian Dominican friar and theologian who synthesised Aristotelian philosophy with Christian doctrine in the Summa Theologica.", 1225, 1274, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", new Guid("20000003-0003-0003-0003-000000000001"), 4, null, null, "Thomas Aquinas", "Christianity / Scholasticism" },
                    { new Guid("10000003-0003-0003-0003-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "German theologian and reformer whose 95 Theses ignited the Protestant Reformation and reshaped Western Christianity.", 1483, 1546, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "German", new Guid("20000003-0003-0003-0003-000000000002"), 4, null, null, "Martin Luther", "Protestantism" },
                    { new Guid("10000003-0003-0003-0003-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Chinese philosopher whose teachings on ethics, family loyalty, and governance became the foundation of East Asian moral and political thought.", -551, -479, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Chinese", new Guid("20000003-0003-0003-0003-000000000003"), 4, null, null, "Confucius", "Confucianism" },
                    { new Guid("10000003-0003-0003-0003-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Indian spiritual teacher whose Four Noble Truths and Eightfold Path founded Buddhism, one of the world's major wisdom traditions.", -563, -483, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Indian", new Guid("20000003-0003-0003-0003-000000000004"), 4, null, null, "Siddhartha Gautama (Buddha)", "Buddhism" },
                    { new Guid("10000003-0003-0003-0003-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Medieval Sephardic Jewish philosopher and Torah scholar whose Guide for the Perplexed harmonised Aristotelian philosophy with Jewish theology.", 1138, 1204, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Andalusian", new Guid("20000003-0003-0003-0003-000000000005"), 4, null, null, "Moses Maimonides", "Judaism" },
                    { new Guid("10000003-0003-0003-0003-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greek philosopher whose ethical and metaphysical writings shaped Western philosophy, Christian scholasticism, and Islamic thought for two millennia.", -384, -322, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greek", new Guid("20000001-0001-0001-0001-000000000007"), 4, null, null, "Aristotle", "Aristotelian Philosophy" },
                    { new Guid("10000003-0003-0003-0003-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Athenian philosopher and founder of the Academy whose theory of Forms and political philosophy profoundly influenced Western thought.", -428, -348, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greek", new Guid("20000003-0003-0003-0003-000000000007"), 4, null, null, "Plato", "Platonism" }
                });

            migrationBuilder.InsertData(
                schema: "demos_contributions",
                table: "contribution",
                columns: new[] { "Id", "BelieverProfileId", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "Significance", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "TraditionName", "Year" },
                values: new object[,]
                {
                    { new Guid("30000003-0003-0003-0003-000000000001"), new Guid("10000003-0003-0003-0003-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Comprehensive theological treatise synthesising Aristotelian philosophy with Christian doctrine across five volumes.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The most influential work of medieval theology and a pillar of Catholic intellectual tradition.", null, null, "Summa Theologica", "Christianity / Scholasticism", 1274 },
                    { new Guid("30000003-0003-0003-0003-000000000002"), new Guid("10000003-0003-0003-0003-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "List of propositions challenging the sale of indulgences and papal authority, posted at Wittenberg in 1517.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Ignited the Protestant Reformation and permanently fractured Western Christendom.", null, null, "95 Theses", "Protestantism", 1517 },
                    { new Guid("30000003-0003-0003-0003-000000000003"), new Guid("10000003-0003-0003-0003-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Luther's translation of the Bible into vernacular German, making scripture accessible to ordinary readers.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Standardised the German language and advanced the principle of individual scriptural engagement.", null, null, "German Translation of Bible", "Protestantism", 1534 },
                    { new Guid("30000003-0003-0003-0003-000000000004"), new Guid("10000003-0003-0003-0003-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Collection of sayings and ideas attributed to Confucius, covering ethics, governance, and personal cultivation.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The foundational text of Confucian thought, shaping East Asian civilisation for over two millennia.", null, null, "Analects", "Confucianism", -500 },
                    { new Guid("30000003-0003-0003-0003-000000000005"), new Guid("10000003-0003-0003-0003-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The core teaching of Buddhism: the truth of suffering, its origin, its cessation, and the path leading to cessation.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The cornerstone of Buddhist philosophy and practice, adopted across Asia and beyond.", null, null, "Four Noble Truths", "Buddhism", -500 },
                    { new Guid("30000003-0003-0003-0003-000000000006"), new Guid("10000003-0003-0003-0003-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Philosophical work harmonising Aristotelian rationalism with Jewish theology for intellectually troubled believers.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The foremost work of medieval Jewish philosophy, influential in both Jewish and Christian scholasticism.", null, null, "Guide for the Perplexed", "Judaism", 1190 },
                    { new Guid("30000003-0003-0003-0003-000000000007"), new Guid("10000003-0003-0003-0003-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Treatise on the nature of the good life, virtue, and human flourishing through rational activity of the soul.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The most influential work of Western ethical philosophy and a foundation of virtue ethics.", null, null, "Nicomachean Ethics", "Aristotelian Philosophy", -340 },
                    { new Guid("30000003-0003-0003-0003-000000000008"), new Guid("10000003-0003-0003-0003-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Investigation into the nature of being, substance, causation, and the first principles of reality.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Defined the discipline of metaphysics and shaped ontological inquiry for two millennia.", null, null, "Metaphysics", "Aristotelian Philosophy", -340 },
                    { new Guid("30000003-0003-0003-0003-000000000009"), new Guid("10000003-0003-0003-0003-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dialogue exploring justice, the ideal state, and the philosopher-king, centred on the Allegory of the Cave.", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "One of the most influential works of philosophy and political theory in Western history.", null, null, "The Republic", "Platonism", -375 }
                });

            migrationBuilder.InsertData(
                schema: "demos_contributions",
                table: "creation",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "CreativeMediumId", "CreatorProfileId", "Description", "Genre", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "Significance", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("30000002-0002-0002-0002-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000002-0002-0002-0002-000000000001"), "Tragedy exploring the moral complexities of revenge, madness, and mortality through the Prince of Denmark.", "Tragedy", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Considered the most influential play in the English language and a cornerstone of Western drama.", null, null, "Hamlet", 1601 },
                    { new Guid("30000002-0002-0002-0002-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000002-0002-0002-0002-000000000001"), "Romance exploring themes of power, magic, forgiveness, and colonial encounter on an enchanted island.", "Romance", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Shakespeare's final solo play and a profound meditation on art, authority, and reconciliation.", null, null, "The Tempest", 1611 },
                    { new Guid("30000002-0002-0002-0002-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000002"), "Monumental fresco cycle depicting scenes from Genesis, painted on the vault of the Sistine Chapel in Vatican City.", "Fresco", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "One of the supreme achievements of Renaissance art and a defining masterpiece of Western visual culture.", null, null, "Sistine Chapel Ceiling", 1512 },
                    { new Guid("30000002-0002-0002-0002-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000002"), "Monumental marble sculpture of the biblical hero David, embodying the Renaissance ideal of human beauty and civic virtue.", "Sculpture", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "A symbol of Florentine strength and one of the most recognised works of sculpture in history.", null, null, "David", 1504 },
                    { new Guid("30000002-0002-0002-0002-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000002-0002-0002-0002-000000000003"), "Collection of preludes and fugues in all 24 major and minor keys, demonstrating the viability of well temperament.", "Keyboard", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "A foundational work for keyboard technique and a touchstone for every subsequent generation of composers.", null, null, "Well-Tempered Clavier", 1722 },
                    { new Guid("30000002-0002-0002-0002-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000002-0002-0002-0002-000000000003"), "Monumental choral setting of the Latin Mass regarded as one of the greatest compositions in the history of music.", "Choral / Sacred", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Represents the culmination of Baroque choral writing and a universal statement of musical faith.", null, null, "Mass in B Minor", 1749 },
                    { new Guid("30000002-0002-0002-0002-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000004"), "Half-length portrait renowned for its sfumato technique, enigmatic expression, and atmospheric landscape.", "Portrait", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The most famous painting in the world and an enduring icon of Renaissance art.", null, null, "Mona Lisa", 1503 },
                    { new Guid("30000002-0002-0002-0002-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000004"), "Mural depicting the moment Christ announces one of his disciples will betray him, painted in the refectory of Santa Maria delle Grazie.", "Mural", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "A masterpiece of narrative composition and one of the most studied works in art history.", null, null, "The Last Supper", 1498 },
                    { new Guid("30000002-0002-0002-0002-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000009"), new Guid("10000002-0002-0002-0002-000000000005"), "Mechanical movable-type printing system that enabled the mass production of books and printed material.", "Mechanical Innovation", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Arguably the most transformative invention of the second millennium, enabling the democratisation of knowledge.", null, null, "Printing Press", 1440 },
                    { new Guid("30000002-0002-0002-0002-000000000010"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000002-0002-0002-0002-000000000005"), "The first major book printed using movable type in the West, a Latin Vulgate Bible of extraordinary craftsmanship.", "Sacred Text", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Demonstrated the commercial and cultural viability of printed books, launching the print revolution.", null, null, "Gutenberg Bible", 1455 },
                    { new Guid("30000002-0002-0002-0002-000000000011"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000002-0002-0002-0002-000000000006"), "Comic opera in four acts based on Beaumarchais's play, blending wit, emotional depth, and social commentary.", "Opera", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "A pinnacle of operatic art that redefined the integration of music and dramatic characterisation.", null, null, "The Marriage of Figaro", 1786 },
                    { new Guid("30000002-0002-0002-0002-000000000012"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000002-0002-0002-0002-000000000006"), "Unfinished Requiem Mass in D minor composed in the final weeks of Mozart's life, completed posthumously.", "Choral / Sacred", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "One of the most celebrated and emotionally powerful sacred choral works ever composed.", null, null, "Requiem", 1791 },
                    { new Guid("30000002-0002-0002-0002-000000000013"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000008"), new Guid("10000002-0002-0002-0002-000000000007"), "Philosophiæ Naturalis Principia Mathematica, laying out the laws of motion and universal gravitation in mathematical form.", "Treatise", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "The single most influential scientific publication in history, unifying terrestrial and celestial mechanics.", null, null, "Principia Mathematica", 1687 },
                    { new Guid("30000002-0002-0002-0002-000000000014"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000008"), new Guid("10000002-0002-0002-0002-000000000007"), "Development of the mathematical method of fluxions, Newton's formulation of infinitesimal calculus.", "Mathematical Method", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Provided the mathematical language essential for physics, engineering, and the modern sciences.", null, null, "Method of Fluxions (Calculus)", 1671 },
                    { new Guid("30000002-0002-0002-0002-000000000015"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000009"), new Guid("10000002-0002-0002-0002-000000000008"), "Watt's improved steam engine with a separate condenser, dramatically increasing thermal efficiency.", "Mechanical Engineering", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Powered the factories, mines, and transport networks of the Industrial Revolution.", null, null, "Steam Engine (Improved)", 1776 }
                });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "creative_medium",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Creative medium has not been set.", null, true, 0, null, null, "Undefined", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Undefined", null, "" });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "creative_medium",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Creative medium is not applicable in this context.", 1, null, true, 1, null, null, "NotApplicable", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Not Applicable", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Creative medium was not specified.", 2, null, true, 2, null, null, "Unspecified", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unspecified", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Creative medium is not known.", 3, null, true, 3, null, null, "Unknown", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unknown", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Written works including prose, poetry, drama, and non-fiction.", 4, null, true, 4, null, null, "Literature", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Literature", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Painting, sculpture, printmaking, and other visual art forms.", 5, null, true, 5, null, null, "VisualArt", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Visual Art", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Composition, performance, and musical theory across all traditions.", 6, null, true, 6, null, null, "Music", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Music", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Design and construction of buildings, monuments, and planned spaces.", 7, null, true, 7, null, null, "Architecture", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Architecture", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Empirical inquiry, experimentation, and systematic knowledge production.", 8, null, true, 8, null, null, "Science", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Science", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Applied invention, engineering, and tool-making for practical ends.", 9, null, true, 9, null, null, "Technology", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Technology", null, "" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Systems of thought, ethics, logic, and metaphysical inquiry.", 10, null, true, 10, null, null, "Philosophy", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Philosophy", null, "" }
                });

            migrationBuilder.InsertData(
                schema: "demos_profiles",
                table: "creator_profile",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "CreativeMediumId", "Description", "EraFrom", "EraTo", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "Nationality", "PersonId", "RecordState", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title" },
                values: new object[,]
                {
                    { new Guid("10000002-0002-0002-0002-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000004"), "English playwright and poet widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist.", 1564, 1616, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English", new Guid("20000002-0002-0002-0002-000000000001"), 4, null, null, "William Shakespeare" },
                    { new Guid("10000002-0002-0002-0002-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), "Italian sculptor, painter, and architect whose works in the Sistine Chapel and the statue of David epitomise Renaissance art.", 1475, 1564, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", new Guid("20000002-0002-0002-0002-000000000002"), 4, null, null, "Michelangelo Buonarroti" },
                    { new Guid("10000002-0002-0002-0002-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), "German composer and musician whose mastery of counterpoint and harmonic organisation profoundly shaped Western classical music.", 1685, 1750, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "German", new Guid("20000002-0002-0002-0002-000000000003"), 4, null, null, "Johann Sebastian Bach" },
                    { new Guid("10000002-0002-0002-0002-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000005"), "Florentine polymath whose paintings, including the Mona Lisa and The Last Supper, set enduring standards for artistic achievement.", 1452, 1519, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", new Guid("20000001-0001-0001-0001-000000000006"), 4, null, null, "Leonardo da Vinci" },
                    { new Guid("10000002-0002-0002-0002-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000009"), "German blacksmith and inventor who introduced mechanical movable-type printing to Europe, revolutionising the dissemination of knowledge.", 1400, 1468, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "German", new Guid("20000002-0002-0002-0002-000000000005"), 4, null, null, "Johannes Gutenberg" },
                    { new Guid("10000002-0002-0002-0002-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000006"), "Austrian composer and child prodigy whose prolific output in symphonies, operas, and chamber music epitomises the Classical era.", 1756, 1791, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Austrian", new Guid("20000002-0002-0002-0002-000000000006"), 4, null, null, "Wolfgang Amadeus Mozart" },
                    { new Guid("10000002-0002-0002-0002-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000008"), "English polymath whose Principia Mathematica and invention of calculus rank among the most influential intellectual creations in history.", 1643, 1727, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English", new Guid("20000001-0001-0001-0001-000000000004"), 4, null, null, "Isaac Newton" },
                    { new Guid("10000002-0002-0002-0002-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("00000000-0000-0000-0000-000000000009"), "Scottish inventor whose improved steam engine with a separate condenser was a decisive technological creation of the Industrial Revolution.", 1736, 1819, "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Scottish", new Guid("20000001-0001-0001-0001-000000000010"), 4, null, null, "James Watt" }
                });

            migrationBuilder.InsertData(
                schema: "demos_profiles",
                table: "discoverer_profile",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "EraFrom", "EraTo", "FieldOfStudy", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "Nationality", "PersonId", "RecordState", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title" },
                values: new object[,]
                {
                    { new Guid("10000001-0001-0001-0001-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Genoese navigator whose transatlantic voyages opened sustained European contact with the Americas.", 1451, 1506, "Navigation and Exploration", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Genoese", new Guid("20000001-0001-0001-0001-000000000001"), 4, null, null, "Christopher Columbus" },
                    { new Guid("10000001-0001-0001-0001-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Renaissance polymath who formulated the heliocentric model of the universe, displacing the Earth from the centre of the cosmos.", 1473, 1543, "Astronomy and Mathematics", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Polish", new Guid("20000001-0001-0001-0001-000000000002"), 4, null, null, "Nicolaus Copernicus" },
                    { new Guid("10000001-0001-0001-0001-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian astronomer and physicist whose telescopic observations and experiments laid the groundwork for modern observational science.", 1564, 1642, "Astronomy and Physics", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", new Guid("20000001-0001-0001-0001-000000000003"), 4, null, null, "Galileo Galilei" },
                    { new Guid("10000001-0001-0001-0001-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English mathematician and natural philosopher who unified celestial and terrestrial mechanics through the laws of motion and universal gravitation.", 1643, 1727, "Physics, Mathematics, and Optics", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English", new Guid("20000001-0001-0001-0001-000000000004"), 4, null, null, "Isaac Newton" },
                    { new Guid("10000001-0001-0001-0001-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English naturalist whose theory of evolution by natural selection transformed the understanding of biological diversity.", 1809, 1882, "Natural History and Biology", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "English", new Guid("20000001-0001-0001-0001-000000000005"), 4, null, null, "Charles Darwin" },
                    { new Guid("10000001-0001-0001-0001-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Florentine polymath whose empirical investigations of anatomy, flight, and engineering anticipated modern scientific method.", 1452, 1519, "Anatomy, Engineering, and Natural Philosophy", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Italian", new Guid("20000001-0001-0001-0001-000000000006"), 4, null, null, "Leonardo da Vinci" },
                    { new Guid("10000001-0001-0001-0001-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greek philosopher who established formal logic and pioneered the systematic classification of knowledge across natural philosophy, ethics, and politics.", -384, -322, "Logic, Natural Philosophy, and Biology", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greek", new Guid("20000001-0001-0001-0001-000000000007"), 4, null, null, "Aristotle" },
                    { new Guid("10000001-0001-0001-0001-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dutch tradesman and self-taught lens grinder who first observed microorganisms, founding the discipline of microbiology.", 1632, 1723, "Microscopy and Microbiology", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Dutch", new Guid("20000001-0001-0001-0001-000000000008"), 4, null, null, "Antonie van Leeuwenhoek" },
                    { new Guid("10000001-0001-0001-0001-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Polish-French physicist and chemist who conducted pioneering research on radioactivity, discovering polonium and radium.", 1867, 1934, "Physics and Chemistry", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Polish-French", new Guid("20000001-0001-0001-0001-000000000009"), 4, null, null, "Marie Curie" },
                    { new Guid("10000001-0001-0001-0001-000000000010"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Scottish inventor and mechanical engineer whose separate condenser transformed steam power and catalysed the Industrial Revolution.", 1736, 1819, "Mechanical Engineering and Thermodynamics", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Scottish", new Guid("20000001-0001-0001-0001-000000000010"), 4, null, null, "James Watt" },
                    { new Guid("10000001-0001-0001-0001-000000000011"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greco-Egyptian astronomer and mathematician whose geocentric model dominated Western and Islamic astronomy for over a millennium.", 100, 170, "Astronomy, Geography, and Mathematics", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Greco-Egyptian", new Guid("20000001-0001-0001-0001-000000000011"), 4, null, null, "Claudius Ptolemy" }
                });

            migrationBuilder.InsertData(
                schema: "demos_contributions",
                table: "discovery",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DiscovererProfileId", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "Latitude", "LocationName", "Longitude", "RecordState", "Significance", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("30000001-0001-0001-0001-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "First sustained European contact with the American continents following the transatlantic voyage of 1492.", new Guid("10000001-0001-0001-0001-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 18.199999999999999, "Caribbean Sea", -66.5, 4, "Initiated the Columbian Exchange and permanently linked the Eastern and Western hemispheres.", null, null, "New World", 1492 },
                    { new Guid("30000001-0001-0001-0001-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The model placing the Sun rather than the Earth at the centre of the universe, published in De Revolutionibus Orbium Coelestium.", new Guid("10000001-0001-0001-0001-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 54.350000000000001, "Frombork, Poland", 19.68, 4, "Overturned the Ptolemaic geocentric model and launched the Scientific Revolution.", null, null, "Heliocentrism", 1543 },
                    { new Guid("30000001-0001-0001-0001-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Telescopic observation of four moons orbiting Jupiter, demonstrating that not all celestial bodies revolve around the Earth.", new Guid("10000001-0001-0001-0001-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 45.409999999999997, "Padua, Italy", 11.880000000000001, 4, "Provided direct observational evidence against geocentrism and bolstered the Copernican model.", null, null, "Moons of Jupiter", 1610 },
                    { new Guid("30000001-0001-0001-0001-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Telescopic observation that Venus exhibits a full set of phases, consistent only with an orbit around the Sun.", new Guid("10000001-0001-0001-0001-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 45.409999999999997, "Padua, Italy", 11.880000000000001, 4, "Decisively refuted the Ptolemaic model and confirmed a heliocentric arrangement of the inner planets.", null, null, "Phases of Venus", 1610 },
                    { new Guid("30000001-0001-0001-0001-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Three laws of motion and the inverse-square law of gravitational attraction, unifying terrestrial and celestial mechanics.", new Guid("10000001-0001-0001-0001-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 52.200000000000003, "Cambridge, England", 0.12, 4, "Established the foundation of classical mechanics and dominated physics for over two centuries.", null, null, "Laws of Motion and Universal Gravitation", 1687 },
                    { new Guid("30000001-0001-0001-0001-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Prism experiments demonstrating that white light is composed of a spectrum of colours that can be separated and recombined.", new Guid("10000001-0001-0001-0001-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 52.200000000000003, "Cambridge, England", 0.12, 4, "Founded the science of optics and overturned the ancient theory that colour is a modification of white light.", null, null, "Composition of White Light", 1672 },
                    { new Guid("30000001-0001-0001-0001-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The mechanism by which organisms with favourable traits are more likely to survive and reproduce, driving evolutionary change.", new Guid("10000001-0001-0001-0001-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 51.329999999999998, "Down House, Kent", 0.050000000000000003, 4, "Provided a unifying explanatory framework for the diversity and adaptation of life on Earth.", null, null, "Natural Selection", 1859 },
                    { new Guid("30000001-0001-0001-0001-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Detailed dissections and anatomical drawings revealing the structure of the human body with unprecedented accuracy.", new Guid("10000001-0001-0001-0001-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 45.460000000000001, "Milan, Italy", 9.1899999999999995, 4, "Advanced understanding of human anatomy centuries ahead of formal medical science.", null, null, "Human Anatomy Studies", 1489 },
                    { new Guid("30000001-0001-0001-0001-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Studies of bird flight and designs for flying machines based on empirical observation of aerodynamic principles.", new Guid("10000001-0001-0001-0001-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 43.770000000000003, "Florence, Italy", 11.25, 4, "Anticipated principles of aerodynamics and inspired centuries of flight research.", null, null, "Principles of Flight", 1505 },
                    { new Guid("30000001-0001-0001-0001-000000000010"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The system of deductive reasoning through syllogisms, establishing logic as a formal discipline.", new Guid("10000001-0001-0001-0001-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 37.969999999999999, "Athens, Greece", 23.719999999999999, 4, "Created the foundation of Western logic that remained definitive until the advent of modern mathematical logic.", null, null, "Formal Logic and Syllogism", -340 },
                    { new Guid("30000001-0001-0001-0001-000000000011"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Systematic observation and categorisation of animal species, distinguishing genera and species by shared characteristics.", new Guid("10000001-0001-0001-0001-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 37.969999999999999, "Athens, Greece", 23.719999999999999, 4, "Pioneered biological taxonomy and remained the basis of natural history classification until Linnaeus.", null, null, "Classification of Living Things", -340 },
                    { new Guid("30000001-0001-0001-0001-000000000012"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "First observation of single-celled organisms through hand-crafted high-powered microscope lenses.", new Guid("10000001-0001-0001-0001-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 52.009999999999998, "Delft, Netherlands", 4.3600000000000003, 4, "Revealed an invisible world of microbial life and founded the discipline of microbiology.", null, null, "Microorganisms", 1676 },
                    { new Guid("30000001-0001-0001-0001-000000000013"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Isolation of two new radioactive elements and pioneering research into the nature of radioactive decay.", new Guid("10000001-0001-0001-0001-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 48.850000000000001, "Paris, France", 2.3500000000000001, 4, "Opened the field of nuclear physics and earned the first Nobel Prizes awarded to a woman.", null, null, "Radioactivity / Polonium and Radium", 1898 },
                    { new Guid("30000001-0001-0001-0001-000000000014"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The insight that condensing steam in a separate vessel dramatically improves the efficiency of the steam engine.", new Guid("10000001-0001-0001-0001-000000000010"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 55.859999999999999, "Glasgow, Scotland", -4.25, 4, "Multiplied the efficiency of steam power and catalysed the Industrial Revolution.", null, null, "Separate Condenser Principle", 1765 }
                });

            migrationBuilder.InsertData(
                schema: "demos_relationships",
                table: "influence",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "InfluenceStrengthId", "InfluenceTypeId", "InfluencedProfileId", "InfluencedProfileTypeId", "InfluencerProfileId", "InfluencerProfileTypeId", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc" },
                values: new object[,]
                {
                    { new Guid("40000001-0001-0001-0001-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aristotle's cosmological and logical framework provided the philosophical scaffolding for Ptolemy's geocentric astronomical model.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000001-0001-0001-0001-000000000011"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aristotle's metaphysics and ethics were the intellectual bedrock on which Aquinas constructed the Summa Theologica.", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000001"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Plato's Academy shaped Aristotle's formative intellectual development; Aristotle's philosophy arose partly in critical dialogue with Plato's theory of Forms.", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000003-0003-0003-0003-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000007"), new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Copernicus's heliocentric model motivated Galileo's telescopic observations that provided the first empirical confirmation.", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000002"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Galileo's kinematics and experimental methodology laid the groundwork on which Newton built his three laws of motion.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000004"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Newton's example of explaining natural phenomena through universal laws inspired Darwin's ambition to find a comparable law for biology.", new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000001-0001-0001-0001-000000000005"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000004"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Gutenberg's printing press enabled the rapid mass reproduction of Luther's 95 Theses, amplifying the Reformation across Europe.", new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000003-0003-0003-0003-000000000002"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000002-0002-0002-0002-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The print revolution expanded literacy and created the reading public that sustained Elizabethan theatre and Shakespeare's audience.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000001"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Gutenberg's press enabled the wide dissemination of De Revolutionibus, ensuring Copernicus's heliocentric theory reached scholars across Europe.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000001-0001-0001-0001-000000000002"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000002-0002-0002-0002-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000010"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Leonardo's insistence on empirical observation and systematic experimentation foreshadowed and influenced Galileo's scientific method.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000011"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Leonardo's anatomical studies and mastery of human proportion influenced Michelangelo's sculptural and painted depiction of the human form.", new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000002"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000004"), new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000012"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Bach's contrapuntal mastery deeply influenced Mozart's later works, particularly his integration of fugal techniques into the Classical style.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000002-0002-0002-0002-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000002-0002-0002-0002-000000000003"), new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000013"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Watt's steam engine powered the global shipping networks that enabled Darwin's Voyage of the Beagle and his collection of worldwide specimens.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000001-0001-0001-0001-000000000005"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000010"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000014"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Leeuwenhoek's pioneering use of precision instruments to reveal invisible phenomena established the tradition of instrument-driven discovery that Curie continued.", new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000001-0001-0001-0001-000000000009"), new Guid("00000000-0000-0000-0000-000000000004"), new Guid("10000001-0001-0001-0001-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000015"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Confucius and Buddha developed parallel Eastern wisdom traditions; their shared cultural milieu fostered complementary ethical frameworks.", new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000005"), new Guid("10000003-0003-0003-0003-000000000004"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000003"), new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000016"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aristotle's rational philosophy was the primary intellectual source for Maimonides's Guide for the Perplexed.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000005"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null },
                    { new Guid("40000001-0001-0001-0001-000000000017"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Maimonides's synthesis of Aristotelian philosophy with monotheistic theology directly informed Aquinas's own scholastic project.", new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000001"), new Guid("00000000-0000-0000-0000-000000000006"), new Guid("10000003-0003-0003-0003-000000000005"), new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, null, null }
                });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "influence_strength",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence strength has not been set.", null, true, 0, null, null, "Undefined", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Undefined", null, "" });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "influence_strength",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence strength is not applicable in this context.", 1, null, true, 1, null, null, "NotApplicable", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Not Applicable", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence strength was not specified.", 2, null, true, 2, null, null, "Unspecified", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unspecified", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence strength is not known.", 3, null, true, 3, null, null, "Unknown", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unknown", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A minor influence with limited or localised impact.", 4, null, true, 4, null, null, "Minor", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Minor", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A moderate influence with noticeable but bounded effect.", 5, null, true, 5, null, null, "Moderate", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Moderate", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A major influence with broad and lasting significance.", 6, null, true, 6, null, null, "Major", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Major", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A transformative influence that fundamentally reshaped a field, tradition, or civilisation.", 7, null, true, 7, null, null, "Transformative", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Transformative", null, "" }
                });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "influence_type",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence type has not been set.", null, true, 0, null, null, "Undefined", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Undefined", null, "" });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "influence_type",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence type is not applicable in this context.", 1, null, true, 1, null, null, "NotApplicable", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Not Applicable", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence type was not specified.", 2, null, true, 2, null, null, "Unspecified", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unspecified", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence type is not known.", 3, null, true, 3, null, null, "Unknown", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unknown", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Direct personal influence through mentorship, collaboration, or immediate contact.", 4, null, true, 4, null, null, "Direct", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Direct", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Indirect influence through works, writings, or cultural legacy rather than personal contact.", 5, null, true, 5, null, null, "Indirect", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Indirect", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence through ideas, theories, or intellectual frameworks.", 6, null, true, 6, null, null, "Intellectual", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Intellectual", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence through religious thought, mysticism, or faith traditions.", 7, null, true, 7, null, null, "Spiritual", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Spiritual", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence through creative expression in visual, literary, or performing arts.", 8, null, true, 8, null, null, "Artistic", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Artistic", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence through empirical discovery, experimentation, or technological innovation.", 9, null, true, 9, null, null, "Scientific", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Scientific", null, "" },
                    { new Guid("00000000-0000-0000-0000-00000000000a"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Influence through systems of thought, ethics, logic, or metaphysics.", 10, null, true, 10, null, null, "Philosophical", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Philosophical", null, "" }
                });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "profile_type",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Profile type has not been set.", null, true, 0, null, null, "Undefined", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Undefined", null, "" });

            migrationBuilder.InsertData(
                schema: "demos_ref",
                table: "profile_type",
                columns: new[] { "Id", "CreatedByPrincipalId", "CreatedOnDateTimeUtc", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "EnumValue", "FromUtc", "ImageFK", "Key", "LastModifiedByPrincipalId", "LastModifiedOnDateTimeUtc", "RecordState", "ReferenceDataType", "StateChangedByPrincipalId", "StateChangedOnDateTimeUtc", "Title", "ToUtc", "Value" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Profile type is not applicable in this context.", 1, null, true, 1, null, null, "NotApplicable", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Not Applicable", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Profile type was not specified.", 2, null, true, 2, null, null, "Unspecified", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unspecified", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Profile type is not known.", 3, null, true, 3, null, null, "Unknown", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Unknown", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "One who expands the boundaries of knowledge through exploration and inquiry.", 4, null, true, 4, null, null, "Discoverer", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Discoverer", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "One who produces enduring works of art, literature, music, or architecture.", 5, null, true, 5, null, null, "Creator", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Creator", null, "" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "One who shapes civilisation through faith, philosophy, or ideological vision.", 6, null, true, 6, null, null, "Believer", "SYSTEM", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, 4, null, null, "Believer", null, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BelieverProfile_Id",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BelieverProfile_PersonId",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BelieverProfile_RecordState",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_BelieverProfileId",
                schema: "demos_contributions",
                table: "contribution",
                column: "BelieverProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_Id",
                schema: "demos_contributions",
                table: "contribution",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_RecordState",
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
                name: "IX_Creation_Id",
                schema: "demos_contributions",
                table: "creation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creation_RecordState",
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
                name: "IX_CreativeMediumReferenceData_Id",
                schema: "demos_ref",
                table: "creative_medium",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_Key",
                schema: "demos_ref",
                table: "creative_medium",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_RecordState",
                schema: "demos_ref",
                table: "creative_medium",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ReferenceDataType");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_ToUtc",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ToUtc");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_CreativeMediumId",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "CreativeMediumId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_Id",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_PersonId",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_RecordState",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_DiscovererProfile_Id",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscovererProfile_PersonId",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscovererProfile_RecordState",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_DiscovererProfileId",
                schema: "demos_contributions",
                table: "discovery",
                column: "DiscovererProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_Id",
                schema: "demos_contributions",
                table: "discovery",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discovery_RecordState",
                schema: "demos_contributions",
                table: "discovery",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_Influence_Id",
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
                name: "IX_Influence_RecordState",
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
                name: "IX_InfluenceStrengthReferenceData_Id",
                schema: "demos_ref",
                table: "influence_strength",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_Key",
                schema: "demos_ref",
                table: "influence_strength",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_RecordState",
                schema: "demos_ref",
                table: "influence_strength",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ReferenceDataType");

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
                name: "IX_InfluenceTypeReferenceData_Id",
                schema: "demos_ref",
                table: "influence_type",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_Key",
                schema: "demos_ref",
                table: "influence_type",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_RecordState",
                schema: "demos_ref",
                table: "influence_type",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "influence_type",
                column: "ReferenceDataType");

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
                name: "IX_ProfileTypeReferenceData_Id",
                schema: "demos_ref",
                table: "profile_type",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_Key",
                schema: "demos_ref",
                table: "profile_type",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_RecordState",
                schema: "demos_ref",
                table: "profile_type",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_ReferenceDataType",
                schema: "demos_ref",
                table: "profile_type",
                column: "ReferenceDataType");

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
                schema: "demos_profiles");

            migrationBuilder.DropTable(
                name: "contribution",
                schema: "demos_contributions");

            migrationBuilder.DropTable(
                name: "creation",
                schema: "demos_contributions");

            migrationBuilder.DropTable(
                name: "creative_medium",
                schema: "demos_ref");

            migrationBuilder.DropTable(
                name: "creator_profile",
                schema: "demos_profiles");

            migrationBuilder.DropTable(
                name: "discoverer_profile",
                schema: "demos_profiles");

            migrationBuilder.DropTable(
                name: "discovery",
                schema: "demos_contributions");

            migrationBuilder.DropTable(
                name: "influence",
                schema: "demos_relationships");

            migrationBuilder.DropTable(
                name: "influence_strength",
                schema: "demos_ref");

            migrationBuilder.DropTable(
                name: "influence_type",
                schema: "demos_ref");

            migrationBuilder.DropTable(
                name: "profile_type",
                schema: "demos_ref");

            migrationBuilder.DropTable(
                name: "MediaContent",
                schema: "demos");
        }
    }
}
