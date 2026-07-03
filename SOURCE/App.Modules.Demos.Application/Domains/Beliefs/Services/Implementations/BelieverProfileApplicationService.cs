using App.Modules.Demos.Application.Domains.Beliefs.Structures.InTransit.Dtos;
using App.Modules.Demos.Application.Domains.Believers.Services;
using App.Modules.Demos.Domain.Domains.Believers.Repositories;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Believers.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="BelieverProfile"/>.
    /// </summary>
    public class BelieverProfileApplicationService
        : SimpleCrustStateAppServiceBase<BelieverProfile, BelieverProfileReadDto>,
          IBelieverProfileApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BelieverProfileApplicationService"/> class.
        /// </summary>
        public BelieverProfileApplicationService(
            IBelieverProfileRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<BelieverProfileReadDto> QueryByPerson(Guid personId)
        {
            return this.ObjectMappingService.ProjectTo<BelieverProfile, BelieverProfileReadDto>(
                this.Repository.Query().Where(e => e.PersonId == personId));
        }
    }
}
