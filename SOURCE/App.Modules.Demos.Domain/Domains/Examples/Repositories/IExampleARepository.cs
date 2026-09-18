using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.Domains.Persistence.Repositories;

namespace App.Modules.Demos.Domain.Domains.Examples.Repositories
{
    /// <summary>CRUST repository contract owned by the Demos Examples slice.</summary>
    /// <remarks>Application services consume this governed surface; controllers never access the DbContext.</remarks>
    public interface IExampleARepository : ICrustStateRepository<ExampleA>
    {
    }
}