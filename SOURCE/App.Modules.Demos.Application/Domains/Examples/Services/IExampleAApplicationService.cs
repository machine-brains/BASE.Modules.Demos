using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;

namespace App.Modules.Demos.Application.Domains.Examples.Services
{
    /// <summary>CRUST application boundary for Demos ExampleA operations.</summary>
    /// <remarks>It owns DTO projection and delegates governed persistence to IExampleARepository through the base service.</remarks>
    public interface IExampleAApplicationService : ICrudStateAppService<ExampleAReadDto, ExampleAWriteDto, ExampleAWriteDto>
    {
        /// <summary>Reads the deterministic Examples demo projection without user-scoped filtering.</summary>
        /// <remarks>
        /// This is a temporary Development-only visual-validation seam for the Spike client.
        /// The normal CRUST collection remains permission/share governed; callers must not use
        /// this method for production data or mutation. The eventual replacement is the normal
        /// authenticated path once the authorization seed/catalogue migration is complete.
        /// </remarks>
        Task<IReadOnlyList<ExampleAReadDto>> GetDeveloperDemoAsync(CancellationToken cancellationToken = default);
    }
}