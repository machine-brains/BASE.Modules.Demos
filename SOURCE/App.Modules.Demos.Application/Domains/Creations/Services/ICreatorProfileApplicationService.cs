using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Creators.Services
{
    /// <summary>
    /// Application service contract for CreatorProfile CRUST operations.
    /// </summary>
    public interface ICreatorProfileApplicationService : ICrudStateAppService<CreatorProfileDto, CreatorProfileDto, CreatorProfileDto>
    {
        /// <summary>Returns creator profiles for the given person.</summary>
        IQueryable<CreatorProfileDto> QueryByPerson(Guid personId);
    }
}
