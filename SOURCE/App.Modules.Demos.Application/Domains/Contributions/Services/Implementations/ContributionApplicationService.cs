using App.Modules.Demos.Application.Domains.Contributions.Services;
using App.Modules.Demos.Application.Domains.Contributions.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Contributions.Repositories;
using App.Modules.Demos.Domain.Domains.Contributions.Structures.AtRest.Entities;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Contributions.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="Contribution"/>.
    /// </summary>
    public class ContributionApplicationService
        : SimpleCrustStateAppServiceBase<Contribution, ContributionReadDto>,
          IContributionApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ContributionApplicationService"/> class.
        /// </summary>
        public ContributionApplicationService(
            IContributionRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<ContributionReadDto> QueryByProfile(Guid believerProfileId)
        {
            return this.ObjectMappingService.ProjectTo<Contribution, ContributionReadDto>(
                this.Repository.Query().Where(e => e.BelieverProfileId == believerProfileId));
        }
    }
}
