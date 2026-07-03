using App.Modules.Demos.Domain.Domains.Discoverers.Repositories;
using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
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
        public DiscoveryRepository(IAppLogger logger, App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

