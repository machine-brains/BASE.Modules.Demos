using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services
{
    /// <summary>
    /// Application service contract for Discovery CRUST operations.
    /// </summary>
    public interface IDiscoveryApplicationService : ICrudStateAppService<DiscoveryDto, DiscoveryDto, DiscoveryDto>
    {
        /// <summary>Returns discoveries for the given discoverer profile.</summary>
        IQueryable<DiscoveryDto> QueryByProfile(Guid discovererProfileId);
    }
}
