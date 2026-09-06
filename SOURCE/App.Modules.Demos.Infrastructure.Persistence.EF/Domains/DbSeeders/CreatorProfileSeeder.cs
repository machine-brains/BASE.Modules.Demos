using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    public sealed class CreatorProfileSeeder : IEntityDataSeeder<CreatorProfile>
    {
        public Task<IEnumerable<CreatorProfile>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            return Task.FromResult(DemoDataSeedData.GetCreatorProfiles());
        }
    }
}