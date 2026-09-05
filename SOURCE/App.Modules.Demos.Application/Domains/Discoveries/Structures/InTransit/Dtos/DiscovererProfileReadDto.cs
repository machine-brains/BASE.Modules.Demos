using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read DTO for <c>DiscovererProfile</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class DiscovererProfileReadDto : DiscovererProfileWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
