using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Sys.Shared.Domains.Initialisation.Services.Seeding;

namespace App.Modules.Demos.Infrastructure.Domains.DbSeeders.DbSeeders
{
    /// <summary>Reflection-discovered deterministic seed data for Demos operation relationships.</summary>
    /// <remarks>Edges connect current ExampleA fixture IDs explicitly; graph projection must never infer them from child containment.</remarks>
    public sealed class DemosOperationRelationshipSeeder : IEntityDataSeeder<DemosOperationRelationship>
    {
        /// <inheritdoc />
        public Task<IEnumerable<DemosOperationRelationship>> GetSeedDeclarationsAsync(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            return Task.FromResult(ExamplesSeedData.GetOperationRelationships());
        }
    }
}