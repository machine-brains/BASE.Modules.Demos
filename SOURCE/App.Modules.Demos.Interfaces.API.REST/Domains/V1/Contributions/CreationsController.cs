using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Demos.Application.Domains.Creators.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Contributions
{
/// <summary>
/// REST API controller for Creation operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.Creations.Base)]
public class CreationsController
: SimpleCrudStateControllerBase<CreationReadDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="CreationsController"/> class.
/// </summary>
/// <param name="service">The creation application service.</param>
public CreationsController(
ICreationApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets creations for a specific creator profile.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="profileId">The unique identifier of the creator profile.</param>
/// <returns>Queryable of <see cref="CreationReadDto"/>.</returns>
/// <response code="200">Returns the matching creations.</response>
[HttpGet("by-profile/{profileId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<CreationReadDto> GetByProfile(Guid profileId)
{
return ((ICreationApplicationService)this.Service).QueryByProfile(profileId);
}
}
}
