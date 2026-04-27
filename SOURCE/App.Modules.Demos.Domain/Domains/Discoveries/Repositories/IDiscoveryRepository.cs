using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Discoverers.Repositories
{
/// <summary>
/// Repository contract for <see cref="Discovery"/> persistence operations.
/// </summary>
public interface IDiscoveryRepository : ICrustStateRepository<Discovery>
{
}
}


