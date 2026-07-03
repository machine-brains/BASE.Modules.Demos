using App.Modules.Sys.Initialisation.Implementation.Base;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Demos.Infrastructure.Persistence.EF.Initialisation.Implementation
{
    /// <summary>
    /// Module assembly initialiser for the Demos EF data layer.
    /// Registers <see cref="ModuleDbContext"/> via the shared helper (ADR-006).
    /// </summary>
    public class ModuleAssemblyInitialiser : ModuleAssemblyInitialiserBase
    {
        /// <inheritdoc/>
        public override void DoBeforeBuild(IServiceCollection services)
        {
            services.AddModuleDbContext<ModuleDbContext>(ModuleConstants.DbSchemaKey);
        }
    }
}
