using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <summary>Aligns the deterministic Demos calendar fixture with the current development month.</summary>
    [DbContext(typeof(App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext))]
    [Migration("20260922100000_AlignExamplesCalendarFixtureDates")]
    public partial class AlignExamplesCalendarFixtureDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [FromUtc] = DATEADD(day, -16, [FromUtc]), [ToUtc] = DATEADD(day, -16, [ToUtc]) " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [IsActive] = 1 AND [FromUtc] >= '2026-10-01T00:00:00+00:00';");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_b] " +
                "SET [FromUtc] = DATEADD(day, -16, [FromUtc]), [ToUtc] = DATEADD(day, -16, [ToUtc]) " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [FromUtc] >= '2026-10-01T00:00:00+00:00';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [FromUtc] = DATEADD(day, 16, [FromUtc]), [ToUtc] = DATEADD(day, 16, [ToUtc]) " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [IsActive] = 1 AND [FromUtc] >= '2026-09-15T00:00:00+00:00' " +
                "AND [FromUtc] < '2026-11-01T00:00:00+00:00';");

            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_b] " +
                "SET [FromUtc] = DATEADD(day, 16, [FromUtc]), [ToUtc] = DATEADD(day, 16, [ToUtc]) " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [FromUtc] >= '2026-09-15T00:00:00+00:00' " +
                "AND [FromUtc] < '2026-11-01T00:00:00+00:00';");
        }
    }
}
