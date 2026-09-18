using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>Reflection-discovered deterministic seeder for Demos ExampleB rows.</summary>
    public sealed class ExampleBSeeder : IEntityDataSeeder<ExampleB>
    {
        /// <inheritdoc/>
        public Task<IEnumerable<ExampleB>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            return Task.FromResult(ExamplesSeedData.GetExampleBs());
        }
    }
}