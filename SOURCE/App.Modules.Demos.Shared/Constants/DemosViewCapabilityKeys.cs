namespace App.Modules.Demos.Constants
{
    /// <summary>
    /// Stable capability keys referenced by the canonical Demos VDL surface.
    /// </summary>
    /// <remarks>
    /// These keys are identifiers for registered source/action providers, not
    /// endpoint paths and not permission grants. A provider resolved by one of
    /// these keys must still call the Demos Application/Repository path, where
    /// parent scope, visibility, classification and state policy are enforced.
    /// The Policy Designer remains a deferred authority for the development pilot;
    /// keeping the keys here prevents VDL from inventing a second data-access path.
    /// </remarks>
    public static class DemosViewCapabilityKeys
    {
        /// <summary>Registered parent collection source.</summary>
        public const string ParentsSource = "demos.examples.parents";

        /// <summary>Registered child collection source requiring a parent scope.</summary>
        public const string ChildrenSource = "demos.examples.children";

        /// <summary>Registered parent read source.</summary>
        public const string ParentReadSource = "demos.examples.parent-read";

        /// <summary>Registered child read source.</summary>
        public const string ChildReadSource = "demos.examples.child-read";

        /// <summary>Registered parent create action.</summary>
        public const string ParentCreateAction = "demos.examples.parent-create";

        /// <summary>Registered child create action.</summary>
        public const string ChildCreateAction = "demos.examples.child-create";

        /// <summary>Registered parent lifecycle transition action.</summary>
        public const string ParentTransitionAction = "demos.examples.parent-transition";

        /// <summary>Registered child lifecycle transition action.</summary>
        public const string ChildTransitionAction = "demos.examples.child-transition";

        /// <summary>Version of the capability contracts used by the first VDL pilot.</summary>
        public const string Version = "1.0";
    }
}
