using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>Reflection-discovered deterministic seeder for Demos ExampleA rows.</summary>
    public sealed class ExampleASeeder : IEntityDataSeeder<ExampleA>
    {
        /// <inheritdoc/>
        public Task<IEnumerable<ExampleA>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            return Task.FromResult(ExamplesSeedData.GetExampleAs());
        }
    }
}