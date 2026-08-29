using App.Modules.Demos;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Discoveries.Permissions
{
/// <summary>
/// Permission constants for the Discoverers domain of the Demos module.
/// </summary>
public class DiscoveriesPermissionsGroup : IPermissionsGroup
{
private const string Grouping = ModuleConstants.Key + ";Discoverers";

[PermissionDescription("Read Discoverer Profiles", "Allow listing and reading Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesRead = "Demos/DiscovererProfiles/Read";
[PermissionDescription("Create Discoverer Profiles", "Allow creating new Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesCreate = "Demos/DiscovererProfiles/Create";
[PermissionDescription("Update Discoverer Profiles", "Allow editing existing Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesUpdate = "Demos/DiscovererProfiles/Update";
[PermissionDescription("Delete Discoverer Profiles", "Allow deleting Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesDelete = "Demos/DiscovererProfiles/Delete";

[PermissionDescription("Read Discoveries", "Allow listing and reading Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesRead = "Demos/Discoveries/Read";
[PermissionDescription("Create Discoveries", "Allow creating new Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesCreate = "Demos/Discoveries/Create";
[PermissionDescription("Update Discoveries", "Allow editing existing Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesUpdate = "Demos/Discoveries/Update";
[PermissionDescription("Delete Discoveries", "Allow deleting Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesDelete = "Demos/Discoveries/Delete";
}
}
