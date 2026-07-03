using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Domain.Domains.Creators.Repositories;
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
        public CreationRepository(IAppLogger logger, App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

