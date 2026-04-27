using App.Modules.Demos;
using App.Modules.Demos.Shared.AccessControl.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Beliefs.Permissions
{
    /// <summary>
    /// Permission constants for the Believers domain of the Demos module.
    /// Each constant is decorated with <see cref="PermissionDefinitionAttribute"/>
    /// for discovery and seeding at startup.
    /// </summary>
    public class BeliefsPermissionsConfigurationObject : IPermissionsConfigurationObject
    {
        private const string Grouping = ModuleConstants.Key + ";Believers";

        /// <summary>Permission to list and read Believer profiles.</summary>
        [PermissionDefinition("Read Believer Profiles", "Allow listing and reading Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesRead = PermissionConstants.BelieverProfiles.Read;

        /// <summary>Permission to create Believer profiles.</summary>
        [PermissionDefinition("Create Believer Profiles", "Allow creating new Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesCreate = PermissionConstants.BelieverProfiles.Create;

        /// <summary>Permission to update Believer profiles.</summary>
        [PermissionDefinition("Update Believer Profiles", "Allow editing existing Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesUpdate = PermissionConstants.BelieverProfiles.Update;

        /// <summary>Permission to delete Believer profiles.</summary>
        [PermissionDefinition("Delete Believer Profiles", "Allow deleting Believer profile records.", Grouping = Grouping + ";BelieverProfiles")]
        public const string BelieverProfilesDelete = PermissionConstants.BelieverProfiles.Delete;

        // Contributions permissions are defined in ContributionsPermissionsConfigurationObject.
        // Duplicating them here causes a conflicting attributed permission key at startup.
    }
}

