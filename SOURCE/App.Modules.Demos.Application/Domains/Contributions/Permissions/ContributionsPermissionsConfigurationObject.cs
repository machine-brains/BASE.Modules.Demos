using App.Modules.Demos;
using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Contributions.Permissions
{
    /// <summary>
    /// Permission constants for the Contributions domain of the Demos module.
    /// </summary>
    public class ContributionsPermissionsPermissionsGroup : IPermissionsGroup
    {
        private const string Grouping = DemosPermissionConstants.ContributionsGrouping;

        /// <summary>Permission to list and read Contributions.</summary>
        [PermissionDescription("Read Contributions", "Allow listing and reading Contribution records.", Grouping = DemosPermissionConstants.ContributionsPermissionGrouping)]
        public const string ContributionsRead = DemosPermissionConstants.ContributionsRead;

        /// <summary>Permission to create Contributions.</summary>
        [PermissionDescription("Create Contributions", "Allow creating new Contribution records.", Grouping = DemosPermissionConstants.ContributionsPermissionGrouping)]
        public const string ContributionsCreate = DemosPermissionConstants.ContributionsCreate;

        /// <summary>Permission to update Contributions.</summary>
        [PermissionDescription("Update Contributions", "Allow editing existing Contribution records.", Grouping = DemosPermissionConstants.ContributionsPermissionGrouping)]
        public const string ContributionsUpdate = DemosPermissionConstants.ContributionsUpdate;

        /// <summary>Permission to delete Contributions.</summary>
        [PermissionDescription("Delete Contributions", "Allow deleting Contribution records.", Grouping = DemosPermissionConstants.ContributionsPermissionGrouping)]
        public const string ContributionsDelete = DemosPermissionConstants.ContributionsDelete;
    }
}
