using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Demos.Application.Domains.Discoverers.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Profiles
{
/// <summary>
/// REST API controller for DiscovererProfile operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.DiscovererProfiles.Base)]
public class DiscovererProfilesController
: SimpleCrudStateControllerBase<DiscovererProfileReadDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="DiscovererProfilesController"/> class.
/// </summary>
/// <param name="service">The discoverer profile application service.</param>
public DiscovererProfilesController(
IDiscovererProfileApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets all discoverer profiles.
/// Use OData <c>$filter</c> or the <c>by-person</c> route to narrow results.
/// Supports OData query options: $filter, $orderby, $top, $skip, $count.
/// </summary>
/// <returns>Queryable of <see cref="DiscovererProfileReadDto"/>.</returns>
/// <response code="200">Returns the matching discoverer profiles.</response>
[HttpGet]
[EnableQuery]
[ProducesResponseType(200)]
public override IQueryable<DiscovererProfileReadDto> GetAll()
{
return this.Service.Query();
}

/// <summary>
/// Gets discoverer profiles for a specific person.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="personId">The unique identifier of the person.</param>
/// <returns>Queryable of <see cref="DiscovererProfileReadDto"/>.</returns>
/// <response code="200">Returns the matching discoverer profiles.</response>
[HttpGet("by-person/{personId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<DiscovererProfileReadDto> GetByPerson(Guid personId)
{
return ((IDiscovererProfileApplicationService)this.Service).QueryByPerson(personId);
}
}
}
