using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Modules.Demos.Infrastructure.Migrations
{
    /// <summary>Corrects spatial fixture values by the region encoded in each ExampleA title.</summary>
    [DbContext(typeof(App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext))]
    [Migration("20261001090000_AlignExamplesSpatialCoordinatesToRegions")]
    public partial class AlignExamplesSpatialCoordinatesToRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE [demos_examples].[example_a] " +
                "SET [Latitude] = CASE " +
                "WHEN [Title] LIKE 'Northland %' THEN -35.7275 " +
                "WHEN [Title] LIKE 'Auckland %' THEN -36.8485 " +
                "WHEN [Title] LIKE 'Waikato %' THEN -37.7870 " +
                "WHEN [Title] LIKE 'Bay of Plenty %' THEN -37.6878 " +
                "WHEN [Title] LIKE 'Wellington %' THEN -41.2866 " +
                "WHEN [Title] LIKE 'Canterbury %' THEN -43.5321 " +
                "WHEN [Title] LIKE 'Otago %' THEN -45.8788 " +
                "ELSE [Latitude] END, " +
                "[Longitude] = CASE " +
                "WHEN [Title] LIKE 'Northland %' THEN 174.3166 " +
                "WHEN [Title] LIKE 'Auckland %' THEN 174.7633 " +
                "WHEN [Title] LIKE 'Waikato %' THEN 175.2793 " +
                "WHEN [Title] LIKE 'Bay of Plenty %' THEN 176.1651 " +
                "WHEN [Title] LIKE 'Wellington %' THEN 174.7756 " +
                "WHEN [Title] LIKE 'Canterbury %' THEN 172.6362 " +
                "WHEN [Title] LIKE 'Otago %' THEN 170.5028 " +
                "ELSE [Longitude] END " +
                "WHERE [WorkspaceFK] = '5044d734-5b0f-5c60-e4de-a090b51396dc' " +
                "AND [IsActive] = 1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // The previous positional backfill was not a stable data meaning and is not restored.
        }
    }
}
