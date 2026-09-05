using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.Demos.Application.Domains.Beliefs.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read DTO for <c>BelieverProfile</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class BelieverProfileReadDto : BelieverProfileWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
