using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;

namespace App.Modules.Demos.Domain.Domains.Discoverers.Repositories
{
    /// <summary>
    /// Repository contract for <see cref="Discovery"/> persistence operations.
    /// </summary>
    public interface IDiscoveryRepository : ICrustStateRepository<Discovery>
    {
    }
}
