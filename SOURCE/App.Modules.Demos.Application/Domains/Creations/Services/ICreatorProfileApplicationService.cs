using App.Modules.Demos.Application.Domains.Creations.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Creators.Services
{
    /// <summary>
    /// Application service contract for CreatorProfile CRUST operations.
    /// </summary>
    public interface ICreatorProfileApplicationService : ICrudStateAppService<CreatorProfileReadDto, CreatorProfileReadDto, CreatorProfileReadDto>
    {
        /// <summary>Returns creator profiles for the given person.</summary>
        IQueryable<CreatorProfileReadDto> QueryByPerson(Guid personId);
    }
}
