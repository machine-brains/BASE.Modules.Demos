using App.Modules.Demos.Domain.Domains.Examples.Repositories;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations
{
    /// <summary>EF-backed CRUST repository for Demos ExampleA records.</summary>
    public class ExampleARepository : CrustStateRepositoryBase<ExampleA>, IExampleARepository
    {
        /// <summary>Initializes the ExampleA repository.</summary>
        public ExampleARepository(IAppLogger logger, ModuleDbContext db)
            : base(logger, db)
        {
        }

        /// <inheritdoc/>
        public override async Task TransitionStateAsync(Guid id, string stateKey, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(stateKey))
            {
                throw new ArgumentException("State cannot be null or whitespace.", nameof(stateKey));
            }

            ExampleA? entity = await this.GetForUpdateAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new InvalidOperationException("ExampleA with ID " + id + " was not found.");
            }

            bool isActive = stateKey switch
            {
                "Active" => true,
                "Inactive" => false,
                _ => throw new InvalidOperationException(
                    "Unsupported ExampleA lifecycle state '" + stateKey + "'. Expected Active or Inactive.")
            };
            
            if (entity.IsActive == isActive)
            {
                throw new InvalidOperationException(
                    "ExampleA is already in lifecycle state '" + stateKey + "'.");
            }
            
            entity.IsActive = isActive;
            await this.DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}