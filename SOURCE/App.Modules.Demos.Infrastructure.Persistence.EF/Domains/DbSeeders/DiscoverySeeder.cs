using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class DiscoverySeeder : IEntityDataSeeder<Discovery>
    {
        public Task<IEnumerable<Discovery>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetDiscoveries());
        }
    }
}