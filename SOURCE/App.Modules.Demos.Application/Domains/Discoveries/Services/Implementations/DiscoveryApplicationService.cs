using App.Modules.Demos.Application.Domains.Discoverers.Services;
using App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Discoverers.Repositories;
using App.Modules.Demos.Domain.Domains.Discoveries.Structures.AtRest.Entities;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="Discovery"/>.
    /// </summary>
    public class DiscoveryApplicationService
        : SimpleCrustStateAppServiceBase<Discovery, DiscoveryReadDto>,
          IDiscoveryApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DiscoveryApplicationService"/> class.
        /// </summary>
        public DiscoveryApplicationService(
            IDiscoveryRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<DiscoveryReadDto> QueryByProfile(Guid discovererProfileId)
        {
            return this.ObjectMappingService.ProjectTo<Discovery, DiscoveryReadDto>(
                this.Repository.Query().Where(e => e.DiscovererProfileId == discovererProfileId));
        }
    }
}

