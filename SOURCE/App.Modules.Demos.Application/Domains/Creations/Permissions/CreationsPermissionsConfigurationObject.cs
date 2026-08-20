using App.Modules.Demos;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Creations.Permissions
{
/// <summary>
/// Permission constants for the Creators domain of the Demos module.
/// </summary>
public class CreationsPermissionsConfigurationObject : IPermissionsGroup
{
private const string Grouping = ModuleConstants.Key + ";Creators";

[PermissionDescription("Read Creator Profiles", "Allow listing and reading Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesRead = "Demos/CreatorProfiles/Read";
[PermissionDescription("Create Creator Profiles", "Allow creating new Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesCreate = "Demos/CreatorProfiles/Create";
[PermissionDescription("Update Creator Profiles", "Allow editing existing Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesUpdate = "Demos/CreatorProfiles/Update";
[PermissionDescription("Delete Creator Profiles", "Allow deleting Creator profile records.", Grouping = Grouping + ";CreatorProfiles")]
public const string CreatorProfilesDelete = "Demos/CreatorProfiles/Delete";

[PermissionDescription("Read Creations", "Allow listing and reading Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsRead = "Demos/Creations/Read";
[PermissionDescription("Create Creations", "Allow creating new Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsCreate = "Demos/Creations/Create";
[PermissionDescription("Update Creations", "Allow editing existing Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsUpdate = "Demos/Creations/Update";
[PermissionDescription("Delete Creations", "Allow deleting Creation records.", Grouping = Grouping + ";Creations")]
public const string CreationsDelete = "Demos/Creations/Delete";
}
}
