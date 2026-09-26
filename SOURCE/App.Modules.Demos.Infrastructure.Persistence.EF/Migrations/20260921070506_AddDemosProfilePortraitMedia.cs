using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDemosProfilePortraitMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Gets or sets the nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Gets or sets the nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 17)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Gets or sets the primary field of study or area of discovery.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Gets or sets the primary field of study or area of discovery.")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "int",
                nullable: true,
                comment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE).",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE).")
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "int",
                nullable: true,
                comment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE).",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE).")
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font.")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<int>(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 17)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "int",
                nullable: true,
                comment: "Approximate end year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate end year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "int",
                nullable: true,
                comment: "Approximate start year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate start year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreativeMediumId",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Opaque identifier for the related Creative Medium aggregate.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Opaque identifier for the related Creative Medium aggregate.")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font.")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<int>(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "TraditionName",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Name of the religious, philosophical, or ideological tradition.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Name of the religious, philosophical, or ideological tradition.")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 17)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "int",
                nullable: true,
                comment: "Approximate end year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate end year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 19)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "int",
                nullable: true,
                comment: "Approximate start year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate start year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 18)
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaReferenceKind is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaReferenceKind is Font.")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AddColumn<int>(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.CreateIndex(
                name: "IX_DiscovererProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_BelieverProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "MediaContentFK");

            migrationBuilder.AddForeignKey(
                name: "FK_believer_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_creator_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_discoverer_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_believer_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile");

            migrationBuilder.DropForeignKey(
                name: "FK_creator_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile");

            migrationBuilder.DropForeignKey(
                name: "FK_discoverer_profile_MediaContents_MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile");

            migrationBuilder.DropIndex(
                name: "IX_DiscovererProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile");

            migrationBuilder.DropIndex(
                name: "IX_CreatorProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile");

            migrationBuilder.DropIndex(
                name: "IX_BelieverProfile_MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "discoverer_profile");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "discoverer_profile");

            migrationBuilder.DropColumn(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "discoverer_profile");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "creator_profile");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "creator_profile");

            migrationBuilder.DropColumn(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "creator_profile");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_profiles",
                table: "believer_profile");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_profiles",
                table: "believer_profile");

            migrationBuilder.DropColumn(
                name: "MediaReferenceKind",
                schema: "demos_profiles",
                table: "believer_profile");

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Gets or sets the nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Gets or sets the nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 14)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Gets or sets the primary field of study or area of discovery.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Gets or sets the primary field of study or area of discovery.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "int",
                nullable: true,
                comment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE).",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Gets or sets the approximate end year of the era in which this person was active (negative for BCE).")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "discoverer_profile",
                type: "int",
                nullable: true,
                comment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE).",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Gets or sets the approximate start year of the era in which this person was active (negative for BCE).")
                .Annotation("Relational:ColumnOrder", 15)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 14)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "int",
                nullable: true,
                comment: "Approximate end year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate end year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "int",
                nullable: true,
                comment: "Approximate start year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate start year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 15)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreativeMediumId",
                schema: "demos_profiles",
                table: "creator_profile",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Opaque identifier for the related Creative Medium aggregate.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Opaque identifier for the related Creative Medium aggregate.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<string>(
                name: "TraditionName",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Name of the religious, philosophical, or ideological tradition.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Name of the religious, philosophical, or ideological tradition.")
                .Annotation("Relational:ColumnOrder", 13)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<string>(
                name: "Nationality",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Nationality or cultural origin.",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Nationality or cultural origin.")
                .Annotation("Relational:ColumnOrder", 14)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<int>(
                name: "EraTo",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "int",
                nullable: true,
                comment: "Approximate end year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate end year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 16)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<int>(
                name: "EraFrom",
                schema: "demos_profiles",
                table: "believer_profile",
                type: "int",
                nullable: true,
                comment: "Approximate start year of active era. Negative = BCE.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Approximate start year of active era. Negative = BCE.")
                .Annotation("Relational:ColumnOrder", 15)
                .OldAnnotation("Relational:ColumnOrder", 18);
        }
    }
}
