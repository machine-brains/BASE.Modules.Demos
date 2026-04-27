using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Shared.Repositories;

namespace App.Modules.Demos.Domain.Domains.Creators.Repositories
{
/// <summary>
/// Repository contract for <see cref="CreatorProfile"/> persistence operations.
/// </summary>
public interface ICreatorProfileRepository : ICrustStateRepository<CreatorProfile>
{
}
}


