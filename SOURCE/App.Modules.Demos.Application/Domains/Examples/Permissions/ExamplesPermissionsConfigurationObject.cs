using App.Modules.Demos.Constants;
using App.Modules.Sys.Shared.Permissions.Attributes;
using App.Modules.Sys.Shared.Permissions.Models;

namespace App.Modules.Demos.Application.Domains.Examples.Permissions
{
    /// <summary>Discoverable permission group for the Demos Examples capability.</summary>
    /// <remarks>The group owns permission metadata; controllers and services retain the standard BASE authorisation pipeline.</remarks>
    public class ExamplesPermissionsConfigurationObject : IPermissionsGroup
    {
        /// <summary>Permission to read ExampleA and ExampleB records.</summary>
        [PermissionDescription("Read Examples", "Allow listing and reading Demos example records.", Grouping = DemosPermissionConstants.ExamplesPermissionGrouping)]
        public const string Read = DemosPermissionConstants.ExamplesRead;

        /// <summary>Permission to create ExampleA and ExampleB records.</summary>
        [PermissionDescription("Create Examples", "Allow creating Demos example records.", Grouping = DemosPermissionConstants.ExamplesPermissionGrouping)]
        public const string Create = DemosPermissionConstants.ExamplesCreate;

        /// <summary>Permission to update ExampleA and ExampleB records.</summary>
        [PermissionDescription("Update Examples", "Allow updating Demos example records.", Grouping = DemosPermissionConstants.ExamplesPermissionGrouping)]
        public const string Update = DemosPermissionConstants.ExamplesUpdate;

        /// <summary>Permission to delete ExampleA and ExampleB records.</summary>
        [PermissionDescription("Delete Examples", "Allow deleting Demos example records.", Grouping = DemosPermissionConstants.ExamplesPermissionGrouping)]
        public const string Delete = DemosPermissionConstants.ExamplesDelete;
        
            /// <summary>Transition ExampleA domain lifecycle state.</summary>
            [PermissionDescription("Transition Examples", "Publish or withdraw Demos parent examples.", Grouping = DemosPermissionConstants.ExamplesPermissionGrouping)]
            public const string Transition = DemosPermissionConstants.ExamplesTransition;
    }
}