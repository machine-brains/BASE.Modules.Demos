using App.Modules.Demos.Application.Domains.Beliefs.Structures.InTransit.Dtos;
using App.Modules.Demos.Application.Domains.Believers.Services;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Profiles
{
    /// <summary>
    /// REST API controller for BelieverProfile operations.
    /// Provides CRUST endpoints with OData queryability.
    /// </summary>
    [Route(ApiRoutes.Rest.V1.BelieverProfiles.Base)]
    public class BelieverProfilesController
    : SimpleCrudStateControllerBase<BelieverProfileReadDto>
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BelieverProfilesController"/> class.
        /// </summary>
        /// <param name="service">The believer profile application service.</param>
        public BelieverProfilesController(
        IBelieverProfileApplicationService service)
        : base(service)
        {
        }

        /// <summary>
        /// Gets believer profiles for a specific person.
        /// Supports OData query options: \\\, \\\, \\\, \\\, \\\.
        /// </summary>
        /// <param name="personId">The unique identifier of the person.</param>
        /// <returns>Queryable of <see cref="BelieverProfileReadDto"/>.</returns>
        /// <response code="200">Returns the matching believer profiles.</response>
        [HttpGet(ApiRoutes.Rest.V1.BelieverProfiles.ByPerson)]
        [EnableQuery]
        [ProducesResponseType(200)]
        public IQueryable<BelieverProfileReadDto> GetByPerson(Guid personId)
        {
            return ((IBelieverProfileApplicationService)this.Service).QueryByPerson(personId);
        }
    }
}
