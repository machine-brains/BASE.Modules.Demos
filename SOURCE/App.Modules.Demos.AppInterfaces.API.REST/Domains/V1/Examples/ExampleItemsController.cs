using App.Modules.Demos.Application.Domains.Examples.Services;
using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Interfaces.API.REST.Domains.Constants;
using App.Modules.Sys.Interfaces.Controllers.Base;
using App.Modules.Sys.Shared.Attributes;
using App.Modules.Sys.Shared.Domains.Presentation.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.V1.Examples
{
    /// <summary>REST controller for ordered Demos ExampleB child records.</summary>
    /// <remarks>The parent relationship remains an explicit ExampleAId in the application DTO and can be filtered through OData.</remarks>
    [Route(ApiRoutes.Rest.V1.ExampleItems.Base)]
    [ForDemoOnly]
    public class ExampleItemsController : CrudStateControllerBase<ExampleBReadDto, ExampleBWriteDto, ExampleBWriteDto>
    {
        private readonly IWebHostEnvironment _environment;

        /// <summary>Initializes the ExampleB controller.</summary>
        public ExampleItemsController(IExampleBApplicationService service, IWebHostEnvironment environment)
            : base(service)
        {
            this._environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        /// <summary>Updates a child while preserving parent scope and mapping expected validation failures.</summary>
        [HttpPut(ApiConstants.StandardRoutes.Update)]
        [ProducesResponseType(typeof(ExampleBReadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public override async Task<ActionResult<ExampleBReadDto>> UpdateAsync(
            Guid id,
            [FromBody] ExampleBWriteDto dto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.UpdateAsync(id, dto, cancellationToken).ConfigureAwait(false);
            }
            catch (InvalidOperationException exception) when (exception.Message.Contains("reparented", StringComparison.Ordinal))
            {
                return this.BadRequest(exception.Message);
            }
        }

        /// <summary>Returns visible child Examples for one visible ExampleA parent.</summary>
        /// <remarks>
        /// Parent scope is a server-owned application/repository constraint. The route parameter is a claim,
        /// not authority, and the service returns no rows when the parent is missing or not visible.
        /// </remarks>
        [HttpGet("by-example-a/{exampleAId:guid}")]
        public async Task<ActionResult<IReadOnlyList<ExampleBReadDto>>> GetByExampleA(
            Guid exampleAId,
            CancellationToken cancellationToken = default)
        {
            return this.Ok(await ((IExampleBApplicationService)this.Service)
                .GetByExampleAAsync(exampleAId, cancellationToken));
        }

        /// <summary>Returns deterministic demo child Examples for unauthenticated visual validation in Development.</summary>
        [HttpGet("developer-demo")]
        public async Task<ActionResult<IReadOnlyList<ExampleBReadDto>>> GetDeveloperDemo(CancellationToken cancellationToken = default)
        {
            if (!this._environment.IsDevelopment())
            {
                return this.NotFound();
            }

            return this.Ok(await ((IExampleBApplicationService)this.Service).GetDeveloperDemoAsync(cancellationToken));
        }

        /// <summary>Returns development-only child options for a selected ExampleA parent.</summary>
        /// <remarks>This endpoint intentionally mirrors the existing development fixture and is not production authorization evidence.</remarks>
        [HttpGet("developer-demo/by-example-a/{exampleAId:guid}")]
        public async Task<ActionResult<IReadOnlyList<ExampleBReadDto>>> GetDeveloperDemoByExampleA(Guid exampleAId, CancellationToken cancellationToken = default)
        {
            if (!this._environment.IsDevelopment())
            {
                return this.NotFound();
            }

            return this.Ok(await ((IExampleBApplicationService)this.Service).GetDeveloperDemoByExampleAAsync(exampleAId, cancellationToken));
        }
    }
}