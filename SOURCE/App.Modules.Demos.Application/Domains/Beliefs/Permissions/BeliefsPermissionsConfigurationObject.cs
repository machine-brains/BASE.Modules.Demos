using App.Modules.Demos;
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
        private const string Grouping = ModuleConstants.Name + ";Believers";

        /// <summary>Permission to list and read Believer profiles.</summary>
        [PermissionDescription("Read Believer Profiles", "Allow listing and reading Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesRead = ModuleConstants.Name + "/BelieverProfiles/Read";

        /// <summary>Permission to create Believer profiles.</summary>
        [PermissionDescription("Create Believer Profiles", "Allow creating new Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesCreate = ModuleConstants.Name + "/BelieverProfiles/Create";

        /// <summary>Permission to update Believer profiles.</summary>
        [PermissionDescription("Update Believer Profiles", "Allow editing existing Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesUpdate = ModuleConstants.Name + "/BelieverProfiles/Update";

        /// <summary>Permission to delete Believer profiles.</summary>
        [PermissionDescription("Delete Believer Profiles", "Allow deleting Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesDelete = ModuleConstants.Name + "/BelieverProfiles/Delete";

        // Contributions permissions are defined in ContributionsPermissionsConfigurationObject.
        // Duplicating them here causes a conflicting attributed permission key at startup.
    }
}

