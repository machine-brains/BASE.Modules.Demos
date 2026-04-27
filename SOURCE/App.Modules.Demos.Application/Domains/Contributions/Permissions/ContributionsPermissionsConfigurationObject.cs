using App.Modules.Demos;
using App.Modules.Demos.Shared.AccessControl.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Contributions.Permissions
{
    /// <summary>
    /// Permission constants for the Contributions domain of the Demos module.
    /// </summary>
    public class ContributionsPermissionsConfigurationObject : IPermissionsConfigurationObject
    {
        private const string Grouping = ModuleConstants.Key + ";Contributions";

        /// <summary>Permission to list and read Contributions.</summary>
        [PermissionDefinition("Read Contributions", "Allow listing and reading Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsRead = PermissionConstants.Contributions.Read;

        /// <summary>Permission to create Contributions.</summary>
        [PermissionDefinition("Create Contributions", "Allow creating new Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsCreate = PermissionConstants.Contributions.Create;

        /// <summary>Permission to update Contributions.</summary>
        [PermissionDefinition("Update Contributions", "Allow editing existing Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsUpdate = PermissionConstants.Contributions.Update;

        /// <summary>Permission to delete Contributions.</summary>
        [PermissionDefinition("Delete Contributions", "Allow deleting Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsDelete = PermissionConstants.Contributions.Delete;
    }
}

