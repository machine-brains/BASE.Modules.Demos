using App.Modules.Demos.Domain.Domains.Discoverers.Repositories;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Contributions
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="Discovery"/>.
    /// </summary>
    public class DiscoveryRepository : CrustStateRepositoryBase<Discovery>, IDiscoveryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryRepository"/> class.
        /// </summary>
        public DiscoveryRepository(IAppLogger logger, Data.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

