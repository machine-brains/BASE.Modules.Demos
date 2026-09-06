using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class DiscovererProfileSeeder : IEntityDataSeeder<DiscovererProfile>
    {
        public Task<IEnumerable<DiscovererProfile>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetDiscovererProfiles());
        }
    }
}