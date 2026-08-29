using App.Modules.Demos;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Relationships.Permissions
{
/// <summary>
/// Permission constants for the Influences domain of the Demos module.
/// </summary>
public class InfluencesPermissionsGroupObject : IPermissionsGroup
{
private const string Grouping = ModuleConstants.Key + ";Influences";

[PermissionDescription("Read Influences", "Allow listing and reading Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesRead = "Demos/Influences/Read";
[PermissionDescription("Create Influences", "Allow creating new Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesCreate = "Demos/Influences/Create";
[PermissionDescription("Update Influences", "Allow editing existing Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesUpdate = "Demos/Influences/Update";
[PermissionDescription("Delete Influences", "Allow deleting Influence relationship records.", Grouping = Grouping + ";Influences")]
public const string InfluencesDelete = "Demos/Influences/Delete";
}
}
