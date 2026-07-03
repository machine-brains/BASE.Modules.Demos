using App.Modules.Demos.Application.Domains.Relationships.Services;
using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Demos.Domain.Domains.Relationships.Repositories;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Relationships.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="Influence"/>.
    /// </summary>
    public class InfluenceApplicationService
        : SimpleCrustStateAppServiceBase<Influence, InfluenceReadDto>,
          IInfluenceApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="InfluenceApplicationService"/> class.
        /// </summary>
        public InfluenceApplicationService(
            IInfluenceRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<InfluenceReadDto> QueryByInfluencer(Guid profileId)
        {
            return this.ObjectMappingService.ProjectTo<Influence, InfluenceReadDto>(
                this.Repository.Query().Where(e => e.InfluencerProfileId == profileId));
        }

        /// <inheritdoc/>
        public IQueryable<InfluenceReadDto> QueryByInfluenced(Guid profileId)
        {
            return this.ObjectMappingService.ProjectTo<Influence, InfluenceReadDto>(
                this.Repository.Query().Where(e => e.InfluencedProfileId == profileId));
        }
    }
}
