using App.Modules.Demos.Domain.Domains.Relationships.Repositories;
using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Relationships
{
    /// <summary>EF-backed governed repository for Demos operation relationships.</summary>
    /// <remarks>Workspace and share visibility remain owned by the inherited CRUST repository policy.</remarks>
    public class DemosOperationRelationshipRepository : CrustStateRepositoryBase<DemosOperationRelationship>, IDemosOperationRelationshipRepository
    {
        /// <summary>Initializes the Demos operation relationship repository.</summary>
        public DemosOperationRelationshipRepository(IAppLogger logger, ModuleDbContext dbContext)
            : base(logger, dbContext)
        {
        }
    }
}