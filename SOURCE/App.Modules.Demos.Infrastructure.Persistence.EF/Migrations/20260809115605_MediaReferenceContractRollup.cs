using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class MediaReferenceContractRollup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ProfileTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropIndex(
                name: "IX_InfluenceTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropIndex(
                name: "IX_InfluenceStrengthReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropIndex(
                name: "IX_CreativeMediumReferenceData_ImageFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.RenameColumn(
                name: "ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                newName: "MediaFK");

            migrationBuilder.RenameColumn(
                name: "ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                newName: "MediaFK");

            migrationBuilder.RenameColumn(
                name: "ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                newName: "MediaFK");

            migrationBuilder.RenameColumn(
                name: "ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                newName: "MediaFK");
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                schema: "demos_ref",
                table: "profile_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Opaque identifier for the related Image aggregate.");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "profile_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaType is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 16);


            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "profile_type",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaType is Font.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                schema: "demos_ref",
                table: "profile_type",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                schema: "demos_ref",
                table: "influence_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Opaque identifier for the related Image aggregate.");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "influence_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaType is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 16);


            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "influence_type",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaType is Font.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                schema: "demos_ref",
                table: "influence_type",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                schema: "demos_ref",
                table: "influence_strength",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Opaque identifier for the related Image aggregate.");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaType is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 16);


            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "influence_strength",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaType is Font.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                schema: "demos_ref",
                table: "influence_strength",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                schema: "demos_ref",
                table: "creative_medium",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Opaque identifier for the related Image aggregate.");

            migrationBuilder.AddColumn<Guid>(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to MediaContent when MediaType is Media. Null otherwise.")
                .Annotation("Relational:ColumnOrder", 16);


            migrationBuilder.AddColumn<string>(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "creative_medium",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true,
                comment: "Font/icon key media source. Should be set only when MediaType is Font.")
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AddColumn<int>(
                name: "MediaType",
                schema: "demos_ref",
                table: "creative_medium",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Discriminator that declares which media source field is active (None, Font, Media).")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageId", "MediaContentFK", "MediaFK", "MediaFontKey" },
                values: new object[] { null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_profile_type_ImageId",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_influence_type_ImageId",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_influence_strength_ImageId",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "MediaContentFK");

            migrationBuilder.CreateIndex(
                name: "IX_creative_medium_ImageId",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "MediaContentFK");

            migrationBuilder.AddForeignKey(
                name: "FK_creative_medium_MediaContents_ImageId",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageId",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_creative_medium_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_strength_MediaContents_ImageId",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageId",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_influence_strength_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_influence_type_MediaContents_ImageId",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageId",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_influence_type_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "MediaContentFK",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_profile_type_MediaContents_ImageId",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageId",
                principalSchema: "sys_core",
                principalTable: "MediaContents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_profile_type_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "profile_type",
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
                name: "FK_creative_medium_MediaContents_ImageId",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropForeignKey(
                name: "FK_creative_medium_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_strength_MediaContents_ImageId",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_strength_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_type_MediaContents_ImageId",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropForeignKey(
                name: "FK_influence_type_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_type_MediaContents_ImageId",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropForeignKey(
                name: "FK_profile_type_MediaContents_MediaContentFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropIndex(
                name: "IX_profile_type_ImageId",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropIndex(
                name: "IX_ProfileTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropIndex(
                name: "IX_influence_type_ImageId",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropIndex(
                name: "IX_InfluenceTypeReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropIndex(
                name: "IX_influence_strength_ImageId",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropIndex(
                name: "IX_InfluenceStrengthReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropIndex(
                name: "IX_creative_medium_ImageId",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropIndex(
                name: "IX_CreativeMediumReferenceData_MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "MediaFK",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "MediaType",
                schema: "demos_ref",
                table: "profile_type");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "MediaFK",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "MediaType",
                schema: "demos_ref",
                table: "influence_type");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "MediaFK",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "MediaType",
                schema: "demos_ref",
                table: "influence_strength");

            migrationBuilder.DropColumn(
                name: "ImageId",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropColumn(
                name: "MediaContentFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropColumn(
                name: "MediaFK",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropColumn(
                name: "MediaFontKey",
                schema: "demos_ref",
                table: "creative_medium");

            migrationBuilder.DropColumn(
                name: "MediaType",
                schema: "demos_ref",
                table: "creative_medium");
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to the MediaContent record representing the image. Null when no image is assigned.")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to the MediaContent record representing the image. Null when no image is assigned.")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to the MediaContent record representing the image. Null when no image is assigned.")
                .Annotation("Relational:ColumnOrder", 14);
















            migrationBuilder.AddColumn<Guid>(
                name: "ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                type: "uniqueidentifier",
                nullable: true,
                comment: "FK to the MediaContent record representing the image. Null when no image is assigned.")
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "creative_medium",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_strength",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "influence_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-00000000000a"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "ImageFK",
                value: null);

            migrationBuilder.UpdateData(
                schema: "demos_ref",
                table: "profile_type",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "ImageFK",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "profile_type",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceTypeReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_type",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_InfluenceStrengthReferenceData_ImageFK",
                schema: "demos_ref",
                table: "influence_strength",
                column: "ImageFK");

            migrationBuilder.CreateIndex(
                name: "IX_CreativeMediumReferenceData_ImageFK",
                schema: "demos_ref",
                table: "creative_medium",
                column: "ImageFK");

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
    }
}
