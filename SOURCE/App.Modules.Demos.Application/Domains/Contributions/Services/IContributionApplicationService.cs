using App.Modules.Demos.Application.Domains.Contributions.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;

namespace App.Modules.Demos.Application.Domains.Contributions.Services
{
    /// <summary>
    /// Application service contract for Contribution CRUST operations.
    /// </summary>
    public interface IContributionApplicationService : ICrudStateAppService<ContributionReadDto, ContributionReadDto, ContributionReadDto>
    {
        /// <summary>Returns contributions for the given believer profile.</summary>
        IQueryable<ContributionReadDto> QueryByProfile(Guid believerProfileId);
    }
}
