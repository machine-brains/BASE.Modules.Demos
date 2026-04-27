using App.Modules.Demos.Domain.Domains.Creators.Repositories;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Profiles
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="CreatorProfile"/>.
    /// </summary>
    public class CreatorProfileRepository : CrustStateRepositoryBase<CreatorProfile>, ICreatorProfileRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatorProfileRepository"/> class.
        /// </summary>
        public CreatorProfileRepository(IAppLogger logger, Data.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

