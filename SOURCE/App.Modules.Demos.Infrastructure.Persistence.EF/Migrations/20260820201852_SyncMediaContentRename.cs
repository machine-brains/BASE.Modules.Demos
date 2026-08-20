using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class SyncMediaContentRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "CreatedOnDateTimeUtc", schema: "demos", table: "MediaContent", newName: "CreatedOnUtc");
            migrationBuilder.RenameColumn(name: "LastModifiedOnDateTimeUtc", schema: "demos", table: "MediaContent", newName: "LastModifiedOnUtc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "CreatedOnUtc", schema: "demos", table: "MediaContent", newName: "CreatedOnDateTimeUtc");
            migrationBuilder.RenameColumn(name: "LastModifiedOnUtc", schema: "demos", table: "MediaContent", newName: "LastModifiedOnDateTimeUtc");
        }
    }
}
