using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class ContributionSeeder : IEntityDataSeeder<Contribution>
    {
        public Task<IEnumerable<Contribution>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetContributions());
        }
    }
}