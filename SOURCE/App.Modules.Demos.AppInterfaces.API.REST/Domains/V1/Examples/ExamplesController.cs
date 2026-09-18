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
    /// <summary>REST controller for the Demos ExampleA parent capability.</summary>
    /// <remarks>The CRUST base supplies collection/read/create/update/state routes and delegates policy to the application boundary.</remarks>
    [Route(ApiRoutes.Rest.V1.Examples.Base)]
    [ForDemoOnly]
    public class ExamplesController : CrudStateControllerBase<ExampleAReadDto, ExampleAWriteDto, ExampleAWriteDto>
    {
        private readonly IWebHostEnvironment _environment;

        /// <summary>Initializes the ExampleA controller.</summary>
        public ExamplesController(IExampleAApplicationService service, IWebHostEnvironment environment)
            : base(service)
        {
            this._environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        /// <summary>Creates a workspace-scoped ExampleA parent with explicit failure semantics.</summary>
        [HttpPost]
        [ProducesResponseType(typeof(ExampleAReadDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult<ExampleAReadDto>> CreateAsync(
            [FromBody] ExampleAWriteDto dto,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await base.CreateAsync(dto, cancellationToken).ConfigureAwait(false);
            }
            catch (UnauthorizedAccessException)
            {
                return this.Unauthorized();
            }
        }

        /// <summary>Returns deterministic demo Examples for unauthenticated visual validation in Development.</summary>
        [HttpGet("developer-demo")]
        public async Task<ActionResult<IReadOnlyList<ExampleAReadDto>>> GetDeveloperDemo(CancellationToken cancellationToken = default)
        {
            if (!this._environment.IsDevelopment())
            {
                return this.NotFound();
            }

            return this.Ok(await ((IExampleAApplicationService)this.Service).GetDeveloperDemoAsync(cancellationToken));
        }
    }
}