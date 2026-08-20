using App.Modules.Demos;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Contributions.Permissions
{
    /// <summary>
    /// Permission constants for the Contributions domain of the Demos module.
    /// </summary>
    public class ContributionsPermissionsConfigurationObject : IPermissionsGroup
    {
        private const string Grouping = ModuleConstants.Key + ";Contributions";

        /// <summary>Permission to list and read Contributions.</summary>
        [PermissionDescription("Read Contributions", "Allow listing and reading Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsRead = "Demos/Contributions/Read";

        /// <summary>Permission to create Contributions.</summary>
        [PermissionDescription("Create Contributions", "Allow creating new Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsCreate = "Demos/Contributions/Create";

        /// <summary>Permission to update Contributions.</summary>
        [PermissionDescription("Update Contributions", "Allow editing existing Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsUpdate = "Demos/Contributions/Update";

        /// <summary>Permission to delete Contributions.</summary>
        [PermissionDescription("Delete Contributions", "Allow deleting Contribution records.", Grouping = Grouping + ";Contributions")]
        public const string ContributionsDelete = "Demos/Contributions/Delete";
    }
}

