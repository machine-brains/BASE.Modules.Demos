using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Demos.Application.Domains.Creators.Services;
using App.Modules.Demos.Domain.Domains.Creators.Repositories;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Creators.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="Creation"/>.
    /// </summary>
    public class CreationApplicationService
        : SimpleCrustStateAppServiceBase<Creation, CreationReadDto>,
          ICreationApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CreationApplicationService"/> class.
        /// </summary>
        public CreationApplicationService(
            ICreationRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<CreationReadDto> QueryByProfile(Guid creatorProfileId)
        {
            return this.ObjectMappingService.ProjectTo<Creation, CreationReadDto>(
                this.Repository.Query().Where(e => e.CreatorProfileId == creatorProfileId));
        }
    }
}

