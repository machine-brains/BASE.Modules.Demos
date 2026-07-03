using App.Modules.Demos.Domain.Domains.Discoverers.Repositories;
using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Profiles
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="DiscovererProfile"/>.
    /// </summary>
    public class DiscovererProfileRepository : CrustStateRepositoryBase<DiscovererProfile>, IDiscovererProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscovererProfileRepository"/> class.
        /// </summary>
        public DiscovererProfileRepository(IAppLogger logger, App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

