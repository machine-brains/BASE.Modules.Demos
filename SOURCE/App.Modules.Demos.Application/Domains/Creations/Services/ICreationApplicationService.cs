using App.Modules.Demos.Application.Domains.Creations.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Creators.Services
{
    /// <summary>
    /// Application service contract for Creation CRUST operations.
    /// </summary>
    public interface ICreationApplicationService : ICrudStateAppService<CreationReadDto, CreationReadDto, CreationReadDto>
    {
        /// <summary>Returns creations for the given creator profile.</summary>
        IQueryable<CreationReadDto> QueryByProfile(Guid creatorProfileId);
    }
}
