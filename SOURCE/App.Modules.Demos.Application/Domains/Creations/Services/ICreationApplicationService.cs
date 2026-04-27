using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Creators.Services
{
    /// <summary>
    /// Application service contract for Creation CRUST operations.
    /// </summary>
    public interface ICreationApplicationService : ICrudStateAppService<CreationDto, CreationDto, CreationDto>
    {
        /// <summary>Returns creations for the given creator profile.</summary>
        IQueryable<CreationDto> QueryByProfile(Guid creatorProfileId);
    }
}
