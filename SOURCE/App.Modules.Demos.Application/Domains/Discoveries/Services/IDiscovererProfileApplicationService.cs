using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Discoverers.Services
{
    /// <summary>
    /// Application service contract for DiscovererProfile CRUST operations.
    /// </summary>
    public interface IDiscovererProfileApplicationService : ICrudStateAppService<DiscovererProfileDto, DiscovererProfileDto, DiscovererProfileDto>
    {
        /// <summary>Returns discoverer profiles for the given person.</summary>
        IQueryable<DiscovererProfileDto> QueryByPerson(Guid personId);
    }
}
