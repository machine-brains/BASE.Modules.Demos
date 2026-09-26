using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <summary>Backfills temporal and spatial values for the current visible Demos fixture rows.</summary>
    [DbContext(typeof(App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext))]
    [Migration("20260922090000_BackfillExamplesTemporalSpatialCapabilities")]
    public partial class BackfillExamplesTemporalSpatialCapabilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "WITH visible AS (" +
                "SELECT [Id], ROW_NUMBER() OVER (ORDER BY [Id]) - 1 AS [Offset] " +
                "FROM [demos_examples].[example_a] " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [IsActive] = 1) " +
                "UPDATE target SET " +
                "[FromUtc] = DATEADD(day, visible.[Offset], CAST('2026-10-01T08:00:00+00:00' AS datetimeoffset)), " +
                "[ToUtc] = DATEADD(hour, 3, DATEADD(day, visible.[Offset], CAST('2026-10-01T08:00:00+00:00' AS datetimeoffset))), " +
                "[Latitude] = CASE (visible.[Offset] % 7) " +
                "WHEN 0 THEN -35.7275 WHEN 1 THEN -36.8485 WHEN 2 THEN -37.7870 " +
                "WHEN 3 THEN -37.6878 WHEN 4 THEN -41.2866 WHEN 5 THEN -43.5321 " +
                "ELSE -45.8788 END, " +
                "[Longitude] = CASE (visible.[Offset] % 7) " +
                "WHEN 0 THEN 174.3166 WHEN 1 THEN 174.7633 WHEN 2 THEN 175.2793 " +
                "WHEN 3 THEN 176.1651 WHEN 4 THEN 174.7756 WHEN 5 THEN 172.6362 " +
                "ELSE 170.5028 END " +
                "FROM [demos_examples].[example_a] AS target INNER JOIN visible ON target.[Id] = visible.[Id];");

            migrationBuilder.Sql(
                "WITH visible AS (" +
                "SELECT [Id], ROW_NUMBER() OVER (ORDER BY [Id]) - 1 AS [Offset] " +
                "FROM [demos_examples].[example_b] " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc') " +
                "UPDATE target SET " +
                "[FromUtc] = DATEADD(hour, visible.[Offset] % 3, DATEADD(day, visible.[Offset] / 2, CAST('2026-10-01T09:00:00+00:00' AS datetimeoffset))), " +
                "[ToUtc] = DATEADD(hour, 1, DATEADD(hour, visible.[Offset] % 3, DATEADD(day, visible.[Offset] / 2, CAST('2026-10-01T09:00:00+00:00' AS datetimeoffset)))), " +
                "[Latitude] = -41.2866 + ((visible.[Offset] % 7) * 0.15), " +
                "[Longitude] = 174.7756 + ((visible.[Offset] % 7) * 0.12) " +
                "FROM [demos_examples].[example_b] AS target INNER JOIN visible ON target.[Id] = visible.[Id];");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This migration restores deterministic fixture meaning; rollback must not erase authored values.
        }
    }
}