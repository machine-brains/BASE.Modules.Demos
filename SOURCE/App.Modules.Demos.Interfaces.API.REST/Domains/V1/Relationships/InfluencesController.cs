using App.Modules.Demos.Application.Domains.Relationships.Services;
using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Relationships
{
/// <summary>
/// REST API controller for Influence relationship operations.
/// Provides CRUST endpoints with OData queryability.
/// </summary>
[Route(ApiRoutes.Rest.V1.Influences.Base)]
public class InfluencesController
: SimpleCrudStateControllerBase<InfluenceReadDto>
{
/// <summary>
/// Initializes a new instance of the
/// <see cref="InfluencesController"/> class.
/// </summary>
/// <param name="service">The influence application service.</param>
public InfluencesController(
IInfluenceApplicationService service)
: base(service)
{
}

/// <summary>
/// Gets influences where the given profile is the influencer.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="profileId">The unique identifier of the influencing profile.</param>
/// <returns>Queryable of <see cref="InfluenceReadDto"/>.</returns>
/// <response code="200">Returns the matching influence relationships.</response>
[HttpGet("by-influencer/{profileId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<InfluenceReadDto> GetByInfluencer(Guid profileId)
{
return ((IInfluenceApplicationService)this.Service).QueryByInfluencer(profileId);
}

/// <summary>
/// Gets influences where the given profile was influenced.
/// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
/// </summary>
/// <param name="profileId">The unique identifier of the influenced profile.</param>
/// <returns>Queryable of <see cref="InfluenceReadDto"/>.</returns>
/// <response code="200">Returns the matching influence relationships.</response>
[HttpGet("by-influenced/{profileId:guid}")]
[EnableQuery]
[ProducesResponseType(200)]
public IQueryable<InfluenceReadDto> GetByInfluenced(Guid profileId)
{
return ((IInfluenceApplicationService)this.Service).QueryByInfluenced(profileId);
}
}
}
