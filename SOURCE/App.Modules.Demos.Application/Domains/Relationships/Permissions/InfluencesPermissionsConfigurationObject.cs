using App.Modules.Demos;
using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Relationships.Permissions
{
    /// <summary>
    /// Permission constants for the Influences domain of the Demos module.
    /// </summary>
    public class InfluencesPermissionsGroupObject : IPermissionsGroup
    {
        private const string Grouping = DemosPermissionConstants.InfluencesGrouping;

        [PermissionDescription("Read Influences", "Allow listing and reading Influence relationship records.", Grouping = DemosPermissionConstants.InfluencesPermissionGrouping)]
        public const string InfluencesRead = DemosPermissionConstants.InfluencesRead;
        [PermissionDescription("Create Influences", "Allow creating new Influence relationship records.", Grouping = DemosPermissionConstants.InfluencesPermissionGrouping)]
        public const string InfluencesCreate = DemosPermissionConstants.InfluencesCreate;
        [PermissionDescription("Update Influences", "Allow editing existing Influence relationship records.", Grouping = DemosPermissionConstants.InfluencesPermissionGrouping)]
        public const string InfluencesUpdate = DemosPermissionConstants.InfluencesUpdate;
        [PermissionDescription("Delete Influences", "Allow deleting Influence relationship records.", Grouping = DemosPermissionConstants.InfluencesPermissionGrouping)]
        public const string InfluencesDelete = DemosPermissionConstants.InfluencesDelete;
    }
}
