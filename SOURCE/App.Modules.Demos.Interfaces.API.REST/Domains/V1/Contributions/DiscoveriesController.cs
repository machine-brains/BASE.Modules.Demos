using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Demos.Application.Domains.Discoverers.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Contributions
{
/// <summary>
/// REST API controller for Discovery operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.Discoveries.Base)]
public class DiscoveriesController
: SimpleCrudStateControllerBase<DiscoveryDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="DiscoveriesController"/> class.
/// </summary>
/// <param name="service">The discovery application service.</param>
public DiscoveriesController(
IDiscoveryApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets discoveries for a specific discoverer profile.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="profileId">The unique identifier of the discoverer profile.</param>
/// <returns>Queryable of <see cref="DiscoveryDto"/>.</returns>
/// <response code="200">Returns the matching discoveries.</response>
[HttpGet("by-profile/{profileId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<DiscoveryDto> GetByProfile(Guid profileId)
{
return ((IDiscoveryApplicationService)this.Service).QueryByProfile(profileId);
}
}
}
