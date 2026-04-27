using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Demos.Application.Domains.Creators.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Profiles
{
/// <summary>
/// REST API controller for CreatorProfile operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.CreatorProfiles.Base)]
public class CreatorProfilesController
: SimpleCrudStateControllerBase<CreatorProfileDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="CreatorProfilesController"/> class.
/// </summary>
/// <param name="service">The creator profile application service.</param>
public CreatorProfilesController(
ICreatorProfileApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets creator profiles for a specific person.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="personId">The unique identifier of the person.</param>
/// <returns>Queryable of <see cref="CreatorProfileDto"/>.</returns>
/// <response code="200">Returns the matching creator profiles.</response>
[HttpGet("by-person/{personId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<CreatorProfileDto> GetByPerson(Guid personId)
{
return ((ICreatorProfileApplicationService)this.Service).QueryByPerson(personId);
}
}
}
