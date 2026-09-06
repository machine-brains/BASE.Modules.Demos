using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class InfluenceSeeder : IEntityDataSeeder<Influence>
    {
        public Task<IEnumerable<Influence>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetInfluences());
        }
    }
}