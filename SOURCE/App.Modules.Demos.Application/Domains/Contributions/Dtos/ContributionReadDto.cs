using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Contributions.Dtos
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
