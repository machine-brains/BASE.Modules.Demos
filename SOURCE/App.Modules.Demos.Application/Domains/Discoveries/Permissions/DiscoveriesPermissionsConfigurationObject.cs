using App.Modules.Demos;
using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Discoveries.Permissions
{
    /// <summary>
    /// Permission constants for the Discoverers domain of the Demos module.
    /// </summary>
    public class DiscoveriesPermissionsGroup : IPermissionsGroup
    {
        private const string Grouping = DemosPermissionConstants.DiscoveriesGrouping;

        [PermissionDescription("Read Discoverer Profiles", "Allow listing and reading Discoverer profile records.", Grouping = DemosPermissionConstants.DiscovererProfilesGrouping)]
        public const string DiscovererProfilesRead = DemosPermissionConstants.DiscovererProfilesRead;
        [PermissionDescription("Create Discoverer Profiles", "Allow creating new Discoverer profile records.", Grouping = DemosPermissionConstants.DiscovererProfilesGrouping)]
        public const string DiscovererProfilesCreate = DemosPermissionConstants.DiscovererProfilesCreate;
        [PermissionDescription("Update Discoverer Profiles", "Allow editing existing Discoverer profile records.", Grouping = DemosPermissionConstants.DiscovererProfilesGrouping)]
        public const string DiscovererProfilesUpdate = DemosPermissionConstants.DiscovererProfilesUpdate;
        [PermissionDescription("Delete Discoverer Profiles", "Allow deleting Discoverer profile records.", Grouping = DemosPermissionConstants.DiscovererProfilesGrouping)]
        public const string DiscovererProfilesDelete = DemosPermissionConstants.DiscovererProfilesDelete;

        [PermissionDescription("Read Discoveries", "Allow listing and reading Discovery records.", Grouping = DemosPermissionConstants.DiscoveriesPermissionGrouping)]
        public const string DiscoveriesRead = DemosPermissionConstants.DiscoveriesRead;
        [PermissionDescription("Create Discoveries", "Allow creating new Discovery records.", Grouping = DemosPermissionConstants.DiscoveriesPermissionGrouping)]
        public const string DiscoveriesCreate = DemosPermissionConstants.DiscoveriesCreate;
        [PermissionDescription("Update Discoveries", "Allow editing existing Discovery records.", Grouping = DemosPermissionConstants.DiscoveriesPermissionGrouping)]
        public const string DiscoveriesUpdate = DemosPermissionConstants.DiscoveriesUpdate;
        [PermissionDescription("Delete Discoveries", "Allow deleting Discovery records.", Grouping = DemosPermissionConstants.DiscoveriesPermissionGrouping)]
        public const string DiscoveriesDelete = DemosPermissionConstants.DiscoveriesDelete;
    }
}
