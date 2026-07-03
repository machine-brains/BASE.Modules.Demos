using App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services
{
    /// <summary>
    /// Application service contract for Discovery CRUST operations.
    /// </summary>
    public interface IDiscoveryApplicationService : ICrudStateAppService<DiscoveryReadDto, DiscoveryReadDto, DiscoveryReadDto>
    {
        /// <summary>Returns discoveries for the given discoverer profile.</summary>
        IQueryable<DiscoveryReadDto> QueryByProfile(Guid discovererProfileId);
    }
}
