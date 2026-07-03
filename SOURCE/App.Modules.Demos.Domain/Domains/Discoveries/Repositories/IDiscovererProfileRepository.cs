using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Discoverers.Repositories
{
/// <summary>
/// Repository contract for <see cref="DiscovererProfile"/> persistence operations.
/// </summary>
public interface IDiscovererProfileRepository : ICrustStateRepository<DiscovererProfile>
{
}
}


