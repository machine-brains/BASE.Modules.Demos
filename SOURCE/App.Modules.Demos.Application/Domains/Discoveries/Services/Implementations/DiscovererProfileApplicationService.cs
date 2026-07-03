using App.Modules.Demos.Application.Domains.Discoverers.Services;
using App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Discoverers.Repositories;
using App.Modules.Demos.Domain.Domains.Discoverers.Structures;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="DiscovererProfile"/>.
    /// </summary>
    public class DiscovererProfileApplicationService
        : SimpleCrustStateAppServiceBase<DiscovererProfile, DiscovererProfileReadDto>,
          IDiscovererProfileApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DiscovererProfileApplicationService"/> class.
        /// </summary>
        public DiscovererProfileApplicationService(
            IDiscovererProfileRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<DiscovererProfileReadDto> QueryByPerson(Guid personId)
        {
            return this.ObjectMappingService.ProjectTo<DiscovererProfile, DiscovererProfileReadDto>(
                this.Repository.Query().Where(e => e.PersonId == personId));
        }
    }
}
