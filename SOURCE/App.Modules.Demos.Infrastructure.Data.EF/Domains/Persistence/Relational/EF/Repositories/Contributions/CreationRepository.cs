using App.Modules.Demos.Domain.Domains.Creators.Repositories;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Contributions
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="Creation"/>.
    /// </summary>
    public class CreationRepository : CrustStateRepositoryBase<Creation>, ICreationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreationRepository"/> class.
        /// </summary>
        public CreationRepository(IAppLogger logger, Data.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

