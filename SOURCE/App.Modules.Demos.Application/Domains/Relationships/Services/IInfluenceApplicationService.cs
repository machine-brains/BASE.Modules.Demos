using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Relationships.Services
{
    /// <summary>
    /// Application service contract for Influence CRUST operations.
    /// </summary>
    public interface IInfluenceApplicationService : ICrudStateAppService<InfluenceReadDto, InfluenceReadDto, InfluenceReadDto>
    {
        /// <summary>Returns influences where the given profile is the influencer.</summary>
        IQueryable<InfluenceReadDto> QueryByInfluencer(Guid profileId);

        /// <summary>Returns influences where the given profile was influenced.</summary>
        IQueryable<InfluenceReadDto> QueryByInfluenced(Guid profileId);
    }
}
