using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;

namespace App.Modules.Demos.Domain.Domains.Examples.Repositories
{
    /// <summary>CRUST repository contract for ordered Demos ExampleB children.</summary>
    /// <remarks>The parent identifier is queried through this boundary and is never resolved by the REST controller.</remarks>
    public interface IExampleBRepository : ICrustStateRepository<ExampleB>
    {
        /// <summary>Returns governed child rows for one visible parent.</summary>
        /// <param name="exampleAId">Parent ExampleA identifier.</param>
        /// <returns>Queryable child source constrained to the parent identity.</returns>
        IQueryable<ExampleB> QueryByExampleAId(Guid exampleAId);
    }
}