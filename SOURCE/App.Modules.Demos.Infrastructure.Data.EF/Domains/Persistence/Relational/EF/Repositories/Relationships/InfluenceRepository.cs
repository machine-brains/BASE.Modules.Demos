using App.Modules.Demos.Domain.Domains.Relationships.Repositories;
using App.Modules.Demos.Shared.Domains.Relationships.Models;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Relationships
{
    /// <summary>
    /// EF Core CRUST repository for <see cref="Influence"/>.
    /// </summary>
    public class InfluenceRepository : CrustStateRepositoryBase<Influence>, IInfluenceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfluenceRepository"/> class.
        /// </summary>
        public InfluenceRepository(IAppLogger logger, Data.EF.ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}

