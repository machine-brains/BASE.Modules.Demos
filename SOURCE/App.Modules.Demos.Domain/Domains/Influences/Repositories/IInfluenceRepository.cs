using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Relationships.Repositories
{
    /// <summary>
    /// Repository contract for <see cref="Influence"/> persistence operations.
    /// </summary>
    public interface IInfluenceRepository : ICrustStateRepository<Influence>
    {
    }
}
