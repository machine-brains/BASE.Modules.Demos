using App.Modules.Demos;
using App.Modules.Demos.Shared.AccessControl.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Relationships.Permissions
{
/// <summary>
/// Permission constants for the Influences domain of the Demos module.
/// </summary>
public class InfluencesPermissionsConfigurationObject : IPermissionsConfigurationObject
{
private const string Grouping = ModuleConstants.Key + ";Influences";

[PermissionDefinition("Read Influences", "Allow listing and reading Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesRead = PermissionConstants.Influences.Read;
[PermissionDefinition("Create Influences", "Allow creating new Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesCreate = PermissionConstants.Influences.Create;
[PermissionDefinition("Update Influences", "Allow editing existing Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesUpdate = PermissionConstants.Influences.Update;
[PermissionDefinition("Delete Influences", "Allow deleting Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesDelete = PermissionConstants.Influences.Delete;
}
}