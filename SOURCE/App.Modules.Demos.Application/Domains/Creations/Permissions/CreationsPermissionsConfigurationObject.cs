using App.Modules.Demos;
using App.Modules.Demos.Shared.AccessControl.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Creations.Permissions
{
/// <summary>
/// Permission constants for the Creators domain of the Demos module.
/// </summary>
public class CreationsPermissionsConfigurationObject : IPermissionsConfigurationObject
{
private const string Grouping = ModuleConstants.Key + ";Creators";

[PermissionDefinition("Read Creator Profiles", "Allow listing and reading Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesRead = PermissionConstants.CreatorProfiles.Read;
[PermissionDefinition("Create Creator Profiles", "Allow creating new Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesCreate = PermissionConstants.CreatorProfiles.Create;
[PermissionDefinition("Update Creator Profiles", "Allow editing existing Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesUpdate = PermissionConstants.CreatorProfiles.Update;
[PermissionDefinition("Delete Creator Profiles", "Allow deleting Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesDelete = PermissionConstants.CreatorProfiles.Delete;

[PermissionDefinition("Read Creations", "Allow listing and reading Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsRead = PermissionConstants.Creations.Read;
[PermissionDefinition("Create Creations", "Allow creating new Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsCreate = PermissionConstants.Creations.Create;
[PermissionDefinition("Update Creations", "Allow editing existing Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsUpdate = PermissionConstants.Creations.Update;
[PermissionDefinition("Delete Creations", "Allow deleting Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsDelete = PermissionConstants.Creations.Delete;
}
}