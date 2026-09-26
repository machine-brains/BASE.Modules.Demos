using App.Modules.Demos.Application.Domains.Relationships.Services;
using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Relationships.Repositories;
using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Sys.Application.Base;
using App.Modules.Sys.Infrastructure.Services;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Application.Domains.Relationships.Services.Implementations
{
    /// <summary>Read Application service for explicit Demos operation relationships.</summary>
    /// <remarks>
    /// The flow is Controller -> this Application service -> IDemosOperationRelationshipRepository -> DbContext.
    /// This service owns DTO projection and query composition; it does not infer or render graph edges.
    /// </remarks>
    public class DemosOperationRelationshipApplicationService : SimpleCrustStateAppServiceBase<DemosOperationRelationship, DemosOperationRelationshipReadDto>, IDemosOperationRelationshipApplicationService
    {
        /// <summary>Initializes the operation relationship Application service.</summary>
        public DemosOperationRelationshipApplicationService(
            IDemosOperationRelationshipRepository repository,
            IObjectMappingService objectMappingService,
            IAppLogger loggingService)
            : base(repository, objectMappingService, loggingService)
        {
        }

        /// <inheritdoc />
        public IQueryable<DemosOperationRelationshipReadDto> QueryBySource(Guid exampleAId)
        {
            return this.ObjectMappingService.ProjectTo<DemosOperationRelationship, DemosOperationRelationshipReadDto>(
                this.Repository.Query().Where(relationship => relationship.SourceExampleAId == exampleAId));
        }

        /// <inheritdoc />
        public IQueryable<DemosOperationRelationshipReadDto> QueryByTarget(Guid exampleAId)
        {
            return this.ObjectMappingService.ProjectTo<DemosOperationRelationship, DemosOperationRelationshipReadDto>(
                this.Repository.Query().Where(relationship => relationship.TargetExampleAId == exampleAId));
        }
    }
}