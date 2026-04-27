using App.Modules.Demos.Application.Domains.Relationships.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Relationships.Services
{
    /// <summary>
    /// Application service contract for Influence CRUST operations.
    /// </summary>
    public interface IInfluenceApplicationService : ICrudStateAppService<InfluenceDto, InfluenceDto, InfluenceDto>
    {
        /// <summary>Returns influences where the given profile is the influencer.</summary>
        IQueryable<InfluenceDto> QueryByInfluencer(Guid profileId);

        /// <summary>Returns influences where the given profile was influenced.</summary>
        IQueryable<InfluenceDto> QueryByInfluenced(Guid profileId);
    }
}
