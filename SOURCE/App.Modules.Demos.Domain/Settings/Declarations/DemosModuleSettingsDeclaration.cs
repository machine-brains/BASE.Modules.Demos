using App.Modules.Sys.Shared.Domains.Settings;

namespace App.Modules.Demos.Domain.Settings.Declarations
{
    /// <summary>
    /// Declares settings exposed by the Demos module.
    /// <para>
    /// These settings control Demos-specific behaviour such as
    /// how much historical data is surfaced by default and whether
    /// the Boorstin Trilogy demo data is loaded on startup.
    /// Discovered at startup and merged into the global settings registry.
    /// </para>
    /// </summary>
    public class DemosModuleSettingsDeclaration : IHasModuleSettingsDeclaration
    {
        /// <inheritdoc />
        public string ModulePrefix => SettingPaths.ModulePrefixes.Demos;

        /// <inheritdoc />
        public IReadOnlyList<SettingDefinition> GetSettingDefinitions()
        {
            return
            [
                // ── Diagnostics / Demo Data ────────────────────────────────
                    new SettingDefinition
                    {
                        Key = SettingPaths.Build(
                            SettingPaths.ModulePrefixes.Demos,
                            SettingPaths.Categories.Diagnostics,
                            "SeedDemoData"),
                        DisplayName = "Seed Demo Data on Startup",
                        Description =
                            "When enabled the Boorstin Trilogy seed data (Discoverers, Creators, " +
                            "Believers and their Influences) is applied during application startup. " +
                            "Disable once the data has been seeded in a given environment.",
                        Category = SettingPaths.Categories.Diagnostics,
                        DataType = "System.Boolean",
                        DefaultValue = "true",
                        Validation = new SettingValidationRule
                        {
                            IsRequired = true,
                        },
                        IsLockedAt = SettingLockFloor.Workspace,
                    },

                    // ── Performance / Profiles ──────────────────────────────────
                    new SettingDefinition
                    {
                        Key = SettingPaths.Build(
                            SettingPaths.ModulePrefixes.Demos,
                            SettingPaths.Categories.Performance,
                            "DefaultProfilePageSize"),
                        DisplayName = "Default Profile Page Size",
                        Description =
                            "Number of profile records (Discoverers, Creators or Believers) " +
                            "returned per page when no explicit $top OData parameter is supplied. " +
                            "Change requires application restart.",
                        Category = SettingPaths.Categories.Performance,
                        DataType = "System.Int32",
                        DefaultValue = "25",
                        Validation = new SettingValidationRule
                        {
                            IsRequired = true,
                            MinValue = 5,
                            MaxValue = 200,
                        },
                        IsLockedAt = SettingLockFloor.Workspace,
                    },

                    // ── Performance / Influence Graph ───────────────────────────
                    new SettingDefinition
                    {
                        Key = SettingPaths.Build(
                            SettingPaths.ModulePrefixes.Demos,
                            SettingPaths.Categories.Performance,
                            "InfluenceGraphMaxDepth"),
                        DisplayName = "Influence Graph Max Depth",
                        Description =
                            "Maximum number of hops to traverse when resolving transitive " +
                            "influence chains for a given profile. Higher values produce richer " +
                            "graphs at the cost of query time.",
                        Category = SettingPaths.Categories.Performance,
                        DataType = "System.Int32",
                        DefaultValue = "3",
                        Validation = new SettingValidationRule
                        {
                            IsRequired = true,
                            MinValue = 1,
                            MaxValue = 10,
                        },
                        IsLockedAt = SettingLockFloor.Workspace,
                    },
            ];
        }
    }
}
