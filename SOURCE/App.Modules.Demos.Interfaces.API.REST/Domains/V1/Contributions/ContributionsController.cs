using App.Modules.Demos.Application.Domains.Contributions.Dtos;
using App.Modules.Demos.Application.Domains.Contributions.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Contributions
{
/// <summary>
/// REST API controller for Contribution operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.Contributions.Base)]
public class ContributionsController
: SimpleCrudStateControllerBase<ContributionReadDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="ContributionsController"/> class.
/// </summary>
/// <param name="service">The contribution application service.</param>
public ContributionsController(
IContributionApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets contributions for a specific believer profile.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="profileId">The unique identifier of the believer profile.</param>
/// <returns>Queryable of <see cref="ContributionReadDto"/>.</returns>
/// <response code="200">Returns the matching contributions.</response>
[HttpGet("by-profile/{profileId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<ContributionReadDto> GetByProfile(Guid profileId)
{
return ((IContributionApplicationService)this.Service).QueryByProfile(profileId);
}
}
}
