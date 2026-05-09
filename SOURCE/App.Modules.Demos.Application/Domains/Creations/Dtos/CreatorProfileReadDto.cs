using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Creators.Dtos
{
    /// <summary>
    /// Read DTO for <c>CreatorProfile</c>. Returned by all GET endpoints and IQueryable projections.
    /// </summary>
    public class CreatorProfileReadDto : CreatorProfileWriteDto, IHasGuidId
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }
    }
}
