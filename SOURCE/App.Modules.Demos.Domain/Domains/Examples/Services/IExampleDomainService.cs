using App.Modules.Sys.Shared.Domains.Services;

namespace App.Modules.Demos.Domain.Domains.Examples.Services
{
    /// <summary>
    /// Domain service contract for ExampleA-specific business rules.
    /// Domain services contain logic that doesn't naturally belong to a single entity.
    /// </summary>
    /// <remarks>
    /// Most modules will have thin domain services — complex business logic
    /// goes here when it spans multiple entities or requires coordination.
    /// Application services orchestrate; domain services encapsulate rules.
    /// </remarks>
    public interface IExampleDomainService : IHasDomainService
    {
    }
}