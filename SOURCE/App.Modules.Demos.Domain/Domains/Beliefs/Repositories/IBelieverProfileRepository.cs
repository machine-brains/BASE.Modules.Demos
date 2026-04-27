using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Believers.Repositories
{
/// <summary>
/// Repository contract for <see cref="BelieverProfile"/> persistence operations.
/// </summary>
public interface IBelieverProfileRepository : ICrustStateRepository<BelieverProfile>
{
}
}


