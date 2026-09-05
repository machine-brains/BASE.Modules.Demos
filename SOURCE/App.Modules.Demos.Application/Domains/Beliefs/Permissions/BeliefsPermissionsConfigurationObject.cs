using App.Modules.Demos;
using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Beliefs.Permissions
{
    /// <summary>
    /// Permission constants for the Believers domain of the Demos module.
    /// Each constant is decorated with <see cref="PermissionDescriptionAttribute"/>
    /// for discovery and seeding at startup.
    /// </summary>
    public class BeliefsPermissionsGroup : IPermissionsGroup
    {
        private const string Grouping = DemosPermissionConstants.BeliefsGrouping;

        /// <summary>Permission to list and read Believer profiles.</summary>
        [PermissionDescription("Read Believer Profiles", "Allow listing and reading Believer profile records.", Grouping = DemosPermissionConstants.BelieverProfilesGrouping)]
        public const string BelieverProfilesRead = DemosPermissionConstants.BelieverProfilesRead;

        /// <summary>Permission to create Believer profiles.</summary>
        [PermissionDescription("Create Believer Profiles", "Allow creating new Believer profile records.", Grouping = DemosPermissionConstants.BelieverProfilesGrouping)]
        public const string BelieverProfilesCreate = DemosPermissionConstants.BelieverProfilesCreate;

        /// <summary>Permission to update Believer profiles.</summary>
        [PermissionDescription("Update Believer Profiles", "Allow editing existing Believer profile records.", Grouping = DemosPermissionConstants.BelieverProfilesGrouping)]
        public const string BelieverProfilesUpdate = DemosPermissionConstants.BelieverProfilesUpdate;

        /// <summary>Permission to delete Believer profiles.</summary>
        [PermissionDescription("Delete Believer Profiles", "Allow deleting Believer profile records.", Grouping = DemosPermissionConstants.BelieverProfilesGrouping)]
        public const string BelieverProfilesDelete = DemosPermissionConstants.BelieverProfilesDelete;

        // Contributions permissions are defined in ContributionsPermissionsConfigurationObject.
        // Duplicating them here causes a conflicting attributed permission key at startup.
    }
}
