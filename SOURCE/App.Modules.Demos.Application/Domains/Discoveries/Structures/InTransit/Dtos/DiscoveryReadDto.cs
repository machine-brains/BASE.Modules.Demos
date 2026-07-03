using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Discoveries.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read DTO for <c>Discovery</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class DiscoveryReadDto : DiscoveryWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
