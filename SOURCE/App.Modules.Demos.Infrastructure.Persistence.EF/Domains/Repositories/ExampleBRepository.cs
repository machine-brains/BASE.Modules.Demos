using App.Modules.Demos.Domain.Domains.Examples.Repositories;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Demos.Infrastructure.Persistence.EF;
using App.Modules.Sys.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Diagnostics;

namespace App.Modules.Demos.Infrastructure.Domains.Persistence.Relational.EF.Repositories.Implementations
{
    /// <summary>EF-backed CRUST repository for Demos ExampleB records.</summary>
    /// <remarks>State operations remain on the standard repository boundary even though ExampleB has no domain-specific state field.</remarks>
    public class ExampleBRepository : CrustStateRepositoryBase<ExampleB>, IExampleBRepository
    {
        /// <summary>Initializes the ExampleB repository.</summary>
        public ExampleBRepository(IAppLogger logger, ModuleDbContext db)
            : base(logger, db)
        {
        }

        /// <inheritdoc />
        public IQueryable<ExampleB> QueryByExampleAId(Guid exampleAId)
        {
            return this.Query()
                .Where(example => example.ExampleAId == exampleAId)
                .OrderBy(example => example.SortOrder);
        }

        /// <inheritdoc/>
        public override async Task TransitionStateAsync(Guid id, string stateKey, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(stateKey))
            {
                throw new ArgumentException("State cannot be null or whitespace.", nameof(stateKey));
            }

            ExampleB? entity = await this.GetForUpdateAsync(id, cancellationToken);
            if (entity is null)
            {
                throw new InvalidOperationException("ExampleB with ID " + id + " was not found.");
            }

            await this.DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}