using App.Modules.Demos;
using App.Modules.Demos.Shared.AccessControl.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Discoveries.Permissions
{
/// <summary>
/// Permission constants for the Discoverers domain of the Demos module.
/// </summary>
public class DiscoveriesPermissionsConfigurationObject : IPermissionsConfigurationObject
{
private const string Grouping = ModuleConstants.Key + ";Discoverers";

[PermissionDefinition("Read Discoverer Profiles", "Allow listing and reading Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesRead = PermissionConstants.DiscovererProfiles.Read;
[PermissionDefinition("Create Discoverer Profiles", "Allow creating new Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesCreate = PermissionConstants.DiscovererProfiles.Create;
[PermissionDefinition("Update Discoverer Profiles", "Allow editing existing Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesUpdate = PermissionConstants.DiscovererProfiles.Update;
[PermissionDefinition("Delete Discoverer Profiles", "Allow deleting Discoverer profile records.", Grouping = Grouping + ";DiscovererProfiles")]
public const string DiscovererProfilesDelete = PermissionConstants.DiscovererProfiles.Delete;

[PermissionDefinition("Read Discoveries", "Allow listing and reading Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesRead = PermissionConstants.Discoveries.Read;
[PermissionDefinition("Create Discoveries", "Allow creating new Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesCreate = PermissionConstants.Discoveries.Create;
[PermissionDefinition("Update Discoveries", "Allow editing existing Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesUpdate = PermissionConstants.Discoveries.Update;
[PermissionDefinition("Delete Discoveries", "Allow deleting Discovery records.", Grouping = Grouping + ";Discoveries")]
public const string DiscoveriesDelete = PermissionConstants.Discoveries.Delete;
}
}