using App.Modules.Demos.Application.Domains.Beliefs.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Application;

namespace App.Modules.Demos.Application.Domains.Believers.Services
{
    /// <summary>
    /// Application service contract for BelieverProfile CRUST operations.
    /// </summary>
    public interface IBelieverProfileApplicationService : ICrudStateAppService<BelieverProfileReadDto, BelieverProfileReadDto, BelieverProfileReadDto>
    {
        /// <summary>Returns believer profiles for the given person.</summary>
        IQueryable<BelieverProfileReadDto> QueryByPerson(Guid personId);
    }
}
