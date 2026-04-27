using App.Modules.Demos.Domain.Domains.Believers.Repositories;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Profiles
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="BelieverProfile"/>.
    /// </summary>
    public class BelieverProfileRepository : CrustStateRepositoryBase<BelieverProfile>, IBelieverProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BelieverProfileRepository"/> class.
        /// </summary>
        public BelieverProfileRepository(IAppLogger logger, Data.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

