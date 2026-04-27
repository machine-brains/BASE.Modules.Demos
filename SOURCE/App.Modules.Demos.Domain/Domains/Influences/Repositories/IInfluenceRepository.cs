using App.Modules.Demos.Shared.Domains.Relationships.Models;
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
