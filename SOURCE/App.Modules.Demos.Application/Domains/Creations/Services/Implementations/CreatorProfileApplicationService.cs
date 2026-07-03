using App.Modules.Demos.Application.Domains.Creations.Structures.InTransit.Dtos;
using App.Modules.Demos.Application.Domains.Creators.Services;
using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models;
using App.Modules.Demos.Domain.Domains.Creators.Repositories;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Creators.Services.Implementations
{
    /// <summary>
    /// CRUST application service for <see cref="CreatorProfile"/>.
    /// </summary>
    public class CreatorProfileApplicationService
        : SimpleCrustStateAppServiceBase<CreatorProfile, CreatorProfileReadDto>,
          ICreatorProfileApplicationService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CreatorProfileApplicationService"/> class.
        /// </summary>
        public CreatorProfileApplicationService(
            ICreatorProfileRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc/>
        public IQueryable<CreatorProfileReadDto> QueryByPerson(Guid personId)
        {
            return this.ObjectMappingService.ProjectTo<CreatorProfile, CreatorProfileReadDto>(
                this.Repository.Query().Where(e => e.PersonId == personId));
        }
    }
}
