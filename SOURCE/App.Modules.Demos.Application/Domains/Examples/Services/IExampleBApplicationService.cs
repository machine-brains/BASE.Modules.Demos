using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;

namespace App.Modules.Demos.Application.Domains.Examples.Services
{
    /// <summary>CRUST application boundary for Demos ExampleB operations.</summary>
    /// <remarks>The split read/write contract keeps CreatedUtc read-only while preserving parent identity and order for Spike.</remarks>
    public interface IExampleBApplicationService : ICrudStateAppService<ExampleBReadDto, ExampleBWriteDto, ExampleBWriteDto>
    {
        /// <summary>Reads visible child records for one visible ExampleA parent.</summary>
        /// <remarks>Parent authorization is composed in the application service before projection; callers cannot widen scope with OData filters.</remarks>
        Task<IReadOnlyList<ExampleBReadDto>> GetByExampleAAsync(Guid exampleAId, CancellationToken cancellationToken = default);

        /// <summary>Reads the deterministic ExampleB demo projection without user-scoped filtering.</summary>
        /// <remarks>This is temporary Development-only visual-validation data; production callers must use the secured CRUST collection.</remarks>
        Task<IReadOnlyList<ExampleBReadDto>> GetDeveloperDemoAsync(CancellationToken cancellationToken = default);

        /// <summary>Reads development-only ExampleB children for one ExampleA parent.</summary>
        /// <remarks>This mirrors the existing development fixture operation and intentionally bypasses normal visibility filters. It must not be used as production authorization evidence.</remarks>
        Task<IReadOnlyList<ExampleBReadDto>> GetDeveloperDemoByExampleAAsync(Guid exampleAId, CancellationToken cancellationToken = default);
    }
}