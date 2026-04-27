using App.Modules.Demos.Application.Domains.Contributions.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Contributions.Services
{
    /// <summary>
    /// Application service contract for Contribution CRUST operations.
    /// </summary>
    public interface IContributionApplicationService : ICrudStateAppService<ContributionDto, ContributionDto, ContributionDto>
    {
        /// <summary>Returns contributions for the given believer profile.</summary>
        IQueryable<ContributionDto> QueryByProfile(Guid believerProfileId);
    }
}
