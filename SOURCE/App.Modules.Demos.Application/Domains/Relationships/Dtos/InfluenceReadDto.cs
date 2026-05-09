using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Relationships.Dtos
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
