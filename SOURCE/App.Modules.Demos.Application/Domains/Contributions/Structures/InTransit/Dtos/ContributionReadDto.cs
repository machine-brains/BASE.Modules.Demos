using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.Demos.Application.Domains.Contributions.Structures.InTransit.Dtos
{
    /// <summary>
    /// Read DTO for <c>Contribution</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class ContributionReadDto : ContributionWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
