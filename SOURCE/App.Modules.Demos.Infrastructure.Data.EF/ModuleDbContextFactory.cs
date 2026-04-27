using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Modules.Demos.Infrastructure.Data.EF
{
    /// <summary>
    /// Design-time factory for the Demos module's <see cref="ModuleDbContext"/>.
    /// Automatically discovered by <c>dotnet ef migrations</c> tooling.
    /// </summary>
    public class ModuleDbContextFactory : IDesignTimeDbContextFactory<ModuleDbContext>
    {
        /// <inheritdoc/>
        public ModuleDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ModuleDbContext> optionsBuilder = new DbContextOptionsBuilder<ModuleDbContext>();
            string connectionString = args.Length > 0
                ? args[0]
                : Environment.GetEnvironmentVariable("ConnectionStrings__Default")
                    ?? $"Server=(localdb)\\mssqllocaldb;Database={PersistenceDbConfiguration.Defaults.DatabaseName};Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString);
            return new ModuleDbContext(optionsBuilder.Options);
        }
    }
}
