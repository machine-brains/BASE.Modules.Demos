using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;

namespace App.Modules.Demos.Domain.Domains.Relationships.Repositories
{
    /// <summary>Governed persistence contract for Demos operation relationships.</summary>
    /// <remarks>The Application service owns projection and relationship queries; this contract keeps DbContext access inside Infrastructure.</remarks>
    public interface IDemosOperationRelationshipRepository : ICrustStateRepository<DemosOperationRelationship>
    {
    }
}