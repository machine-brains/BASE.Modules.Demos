using App.Modules.Demos;
using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Creations.Permissions
{
    /// <summary>
    /// Permission constants for the Creators domain of the Demos module.
    /// </summary>
    public class CreationsPermissionsPermissionsGroup : IPermissionsGroup
    {
        private const string Grouping = DemosPermissionConstants.CreationsGrouping;

        [PermissionDescription("Read Creator Profiles", "Allow listing and reading Creator profile records.", Grouping = DemosPermissionConstants.CreatorProfilesGrouping)]
        public const string CreatorProfilesRead = DemosPermissionConstants.CreatorProfilesRead;
        [PermissionDescription("Create Creator Profiles", "Allow creating new Creator profile records.", Grouping = DemosPermissionConstants.CreatorProfilesGrouping)]
        public const string CreatorProfilesCreate = DemosPermissionConstants.CreatorProfilesCreate;
        [PermissionDescription("Update Creator Profiles", "Allow editing existing Creator profile records.", Grouping = DemosPermissionConstants.CreatorProfilesGrouping)]
        public const string CreatorProfilesUpdate = DemosPermissionConstants.CreatorProfilesUpdate;
        [PermissionDescription("Delete Creator Profiles", "Allow deleting Creator profile records.", Grouping = DemosPermissionConstants.CreatorProfilesGrouping)]
        public const string CreatorProfilesDelete = DemosPermissionConstants.CreatorProfilesDelete;

        [PermissionDescription("Read Creations", "Allow listing and reading Creation records.", Grouping = DemosPermissionConstants.CreationsPermissionGrouping)]
        public const string CreationsRead = DemosPermissionConstants.CreationsRead;
        [PermissionDescription("Create Creations", "Allow creating new Creation records.", Grouping = DemosPermissionConstants.CreationsPermissionGrouping)]
        public const string CreationsCreate = DemosPermissionConstants.CreationsCreate;
        [PermissionDescription("Update Creations", "Allow editing existing Creation records.", Grouping = DemosPermissionConstants.CreationsPermissionGrouping)]
        public const string CreationsUpdate = DemosPermissionConstants.CreationsUpdate;
        [PermissionDescription("Delete Creations", "Allow deleting Creation records.", Grouping = DemosPermissionConstants.CreationsPermissionGrouping)]
        public const string CreationsDelete = DemosPermissionConstants.CreationsDelete;
    }
}
