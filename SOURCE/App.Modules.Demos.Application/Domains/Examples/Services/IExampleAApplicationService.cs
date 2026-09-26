using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;
using App.Modules.Sys.Substrate.Domains.Browse.Models;
using App.Modules.Sys.Shared.Domains.Queries;

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

        /// <summary>Gets the source-aware query capability owned by the ExampleA Browse resource.</summary>
        BrowseQueryCapability GetQueryCapability();

        /// <summary>Applies canonical Coordinator query intent to the governed ExampleA read model.</summary>
        Task<QueryPageResult<ExampleAReadDto>> SearchAsync(QueryInstructionPackage query, CancellationToken cancellationToken = default);
    }
}