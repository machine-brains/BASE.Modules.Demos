using App.Modules.Demos.Application.Domains.Believers.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Believers.Services
{
    /// <summary>
    /// Application service contract for BelieverProfile CRUST operations.
    /// </summary>
    public interface IBelieverProfileApplicationService : ICrudStateAppService<BelieverProfileDto, BelieverProfileDto, BelieverProfileDto>
    {
        /// <summary>Returns believer profiles for the given person.</summary>
        IQueryable<BelieverProfileDto> QueryByPerson(Guid personId);
    }
}
