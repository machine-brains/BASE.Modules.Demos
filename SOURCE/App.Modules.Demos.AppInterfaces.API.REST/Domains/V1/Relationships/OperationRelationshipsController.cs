using App.Modules.Demos.Application.Domains.Relationships.Services;
using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Relationships
{
    /// <summary>REST controller for explicit peer relationships between Demos operations.</summary>
    /// <remarks>The controller delegates visibility, projection and query composition to the Demos Application service.</remarks>
    [Route(ApiRoutes.Rest.V1.OperationRelationships.Base)]
    public class OperationRelationshipsController : ReadControllerBase<DemosOperationRelationshipReadDto>
    {
        /// <summary>Initializes the operation relationship controller.</summary>
        public OperationRelationshipsController(IDemosOperationRelationshipApplicationService service)
            : base(service)
        {
        }

        /// <summary>Gets relationships whose source is the specified ExampleA operation.</summary>
        [HttpGet(ApiRoutes.Rest.V1.OperationRelationships.BySource)]
        [EnableQuery]
        [ProducesResponseType(200)]
        public IQueryable<DemosOperationRelationshipReadDto> GetBySource(Guid exampleAId)
        {
            return ((IDemosOperationRelationshipApplicationService)this.ReadService).QueryBySource(exampleAId);
        }

        /// <summary>Gets relationships whose target is the specified ExampleA operation.</summary>
        [HttpGet(ApiRoutes.Rest.V1.OperationRelationships.ByTarget)]
        [EnableQuery]
        [ProducesResponseType(200)]
        public IQueryable<DemosOperationRelationshipReadDto> GetByTarget(Guid exampleAId)
        {
            return ((IDemosOperationRelationshipApplicationService)this.ReadService).QueryByTarget(exampleAId);
        }
    }
}