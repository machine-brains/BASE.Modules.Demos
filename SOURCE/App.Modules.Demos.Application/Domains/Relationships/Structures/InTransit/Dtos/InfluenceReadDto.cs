using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read DTO for <c>Influence</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class InfluenceReadDto : InfluenceWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
