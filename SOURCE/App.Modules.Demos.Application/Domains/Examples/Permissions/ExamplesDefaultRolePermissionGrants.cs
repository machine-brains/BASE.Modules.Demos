using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Domains.AccessControl.Constants;
using App.Modules.Sys.Shared.Domains.AccessControl.Definitions;
using App.Modules.Sys.Shared.Domains.AccessControl.Models;

namespace App.Modules.Demos.Application.Domains.Examples.Permissions
{
    /// <summary>
    /// Default role grants contributed by the Demos Examples capability.
    /// </summary>
    /// <remarks>
    /// The Demos module owns the policy intent, while Sys discovers this
    /// parameterless container and persists missing role-permission rows through
    /// <c>DefaultRolePermissionGrantsDbSeederInitialiser</c>. Runtime evaluation
    /// then follows <c>RoleAssignment -> RoleDefinitionPermission</c>; this is
    /// deliberately not a legacy direct-user grant or a controller bypass.
    /// </remarks>
    public sealed class ExamplesDefaultRolePermissionGrants : IDefaultRolePermissionGrants
    {
        /// <inheritdoc />
        public IReadOnlyList<DefaultRolePermissionGrant> Grants { get; } =
        [
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Administrator, DemosPermissionConstants.ExamplesRead),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Administrator, DemosPermissionConstants.ExamplesCreate),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Administrator, DemosPermissionConstants.ExamplesUpdate),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Administrator, DemosPermissionConstants.ExamplesDelete),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Administrator, DemosPermissionConstants.ExamplesTransition),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Developer, DemosPermissionConstants.ExamplesRead),
            new DefaultRolePermissionGrant(SystemRoleKeys.Platform.Developer, DemosPermissionConstants.ExamplesTransition),
        ];
    }
}