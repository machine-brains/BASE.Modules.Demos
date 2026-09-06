using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class BelieverProfileSeeder : IEntityDataSeeder<BelieverProfile>
    {
        public Task<IEnumerable<BelieverProfile>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetBelieverProfiles());
        }
    }
}