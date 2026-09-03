using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Relationships.Repositories;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.Repositories.Relationships
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="Influence"/>.
    /// </summary>
    public class InfluenceRepository : CrustStateRepositoryBase<Influence>, IInfluenceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfluenceRepository"/> class.
        /// </summary>
        public InfluenceRepository(IAppLogger logger, App.Modules.Demos.Infrastructure.Persistence.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

