namespace App.Modules.Demos.Shared.AccessControl.Constants
{
    /// <summary>
    /// Permission constants for the Demos module.
    /// <para>
    /// Follows the pattern: <c>{Module}.{Domain}.{Action}</c>.
    /// All strings are constants to support compile-time policy and
    /// attribute-decorated controller demands without magic strings.
    /// </para>
    /// </summary>
    public static class PermissionConstants
    {
#pragma warning disable CS1591
        private const string S = ".";

        /// <summary>Module prefix for all Demos permissions.</summary>
        private const string Module = "Demos";

        /// <summary>
        /// Permissions for Discoverer profiles.
        /// </summary>
        public static class DiscovererProfiles
        {
            private const string Domain = Module + S + "DiscovererProfiles";

            /// <summary>Permission to list and read Discoverer profiles.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Discoverer profiles.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Discoverer profiles.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Discoverer profiles.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Creator profiles.
        /// </summary>
        public static class CreatorProfiles
        {
            private const string Domain = Module + S + "CreatorProfiles";

            /// <summary>Permission to list and read Creator profiles.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Creator profiles.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Creator profiles.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Creator profiles.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Believer profiles.
        /// </summary>
        public static class BelieverProfiles
        {
            private const string Domain = Module + S + "BelieverProfiles";

            /// <summary>Permission to list and read Believer profiles.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Believer profiles.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Believer profiles.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Believer profiles.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Discoveries (contributions by Discoverers).
        /// </summary>
        public static class Discoveries
        {
            private const string Domain = Module + S + "Discoveries";

            /// <summary>Permission to list and read Discoveries.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Discoveries.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Discoveries.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Discoveries.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Creations (contributions by Creators).
        /// </summary>
        public static class Creations
        {
            private const string Domain = Module + S + "Creations";

            /// <summary>Permission to list and read Creations.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Creations.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Creations.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Creations.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Contributions (contributions by Believers).
        /// </summary>
        public static class Contributions
        {
            private const string Domain = Module + S + "Contributions";

            /// <summary>Permission to list and read Contributions.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Contributions.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Contributions.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Contributions.</summary>
            public const string Delete = Domain + S + "Delete";
        }

        /// <summary>
        /// Permissions for Influence relationships between profiles.
        /// </summary>
        public static class Influences
        {
            private const string Domain = Module + S + "Influences";

            /// <summary>Permission to list and read Influence relationships.</summary>
            public const string Read = Domain + S + "Read";

            /// <summary>Permission to create Influence relationships.</summary>
            public const string Create = Domain + S + "Create";

            /// <summary>Permission to update Influence relationships.</summary>
            public const string Update = Domain + S + "Update";

            /// <summary>Permission to delete Influence relationships.</summary>
            public const string Delete = Domain + S + "Delete";
        }
#pragma warning restore CS1591
    }
}
