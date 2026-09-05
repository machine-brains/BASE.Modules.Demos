using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;

namespace App.Modules.Demos.Domain.Domains.Contributions.Repositories
{
    /// <summary>
    /// Repository contract for <see cref="Contribution"/> persistence operations.
    /// </summary>
    public interface IContributionRepository : ICrustStateRepository<Contribution>
    {
    }
}
