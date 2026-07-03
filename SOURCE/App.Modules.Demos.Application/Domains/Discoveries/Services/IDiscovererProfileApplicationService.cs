using App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services
{
    /// <summary>
    /// Application service contract for DiscovererProfile CRUST operations.
    /// </summary>
    public interface IDiscovererProfileApplicationService : ICrudStateAppService<DiscovererProfileReadDto, DiscovererProfileReadDto, DiscovererProfileReadDto>
    {
        /// <summary>Returns discoverer profiles for the given person.</summary>
        IQueryable<DiscovererProfileReadDto> QueryByPerson(Guid personId);
    }
}
