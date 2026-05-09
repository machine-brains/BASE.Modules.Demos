using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Believers.Dtos
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
