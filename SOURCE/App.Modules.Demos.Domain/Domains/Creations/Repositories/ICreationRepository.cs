using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Creators.Repositories
{
/// <summary>
/// Repository contract for <see cref="Creation"/> persistence operations.
/// </summary>
public interface ICreationRepository : ICrustStateRepository<Creation>
{
}
}


