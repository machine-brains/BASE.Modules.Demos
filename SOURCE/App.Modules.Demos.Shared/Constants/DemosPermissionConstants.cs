namespace App.Modules.Demos.Constants
{
    /// <summary>
    /// Permission keys owned by the Demos logical module.
    /// </summary>
    public static class DemosPermissionConstants
    {
        private const string DiscovererProfilesPrefix = ModuleConstants.Name + "/DiscovererProfiles/";
        private const string DiscoveriesPrefix = ModuleConstants.Name + "/Discoveries/";
        private const string BelieverProfilesPrefix = ModuleConstants.Name + "/BelieverProfiles/";
        private const string CreatorProfilesPrefix = ModuleConstants.Name + "/CreatorProfiles/";
        private const string CreationsPrefix = ModuleConstants.Name + "/Creations/";
        private const string ContributionsPrefix = ModuleConstants.Name + "/Contributions/";
        private const string InfluencesPrefix = ModuleConstants.Name + "/Influences/";

        /// <summary>Permission grouping for the Demos discoverer domain.</summary>
        public const string DiscoveriesGrouping = ModuleConstants.Key + ";Discoverers";

        /// <summary>Permission grouping for discoverer profiles.</summary>
        public const string DiscovererProfilesGrouping = DiscoveriesGrouping + ";DiscovererProfiles";

        /// <summary>Permission grouping for discoveries.</summary>
        public const string DiscoveriesPermissionGrouping = DiscoveriesGrouping + ";Discoveries";

        /// <summary>Permission grouping for the Demos believer domain.</summary>
        public const string BeliefsGrouping = ModuleConstants.Name + ";Believers";

        /// <summary>Permission grouping for believer profiles.</summary>
        public const string BelieverProfilesGrouping = BeliefsGrouping + ";BelieverProfiles";

        /// <summary>Permission grouping for the Demos creator domain.</summary>
        public const string CreationsGrouping = ModuleConstants.Key + ";Creators";

        /// <summary>Permission grouping for creator profiles.</summary>
        public const string CreatorProfilesGrouping = CreationsGrouping + ";CreatorProfiles";

        /// <summary>Permission grouping for creations.</summary>
        public const string CreationsPermissionGrouping = CreationsGrouping + ";Creations";

        /// <summary>Permission grouping for contributions.</summary>
        public const string ContributionsGrouping = ModuleConstants.Key + ";Contributions";

        /// <summary>Permission grouping for contribution records.</summary>
        public const string ContributionsPermissionGrouping = ContributionsGrouping + ";Contributions";

        /// <summary>Permission grouping for influences.</summary>
        public const string InfluencesGrouping = ModuleConstants.Key + ";Influences";

        /// <summary>Permission grouping for influence records.</summary>
        public const string InfluencesPermissionGrouping = InfluencesGrouping + ";Influences";

        /// <summary>Read believer profile records.</summary>
        public const string BelieverProfilesRead = BelieverProfilesPrefix + "Read";

        /// <summary>Create believer profile records.</summary>
        public const string BelieverProfilesCreate = BelieverProfilesPrefix + "Create";

        /// <summary>Update believer profile records.</summary>
        public const string BelieverProfilesUpdate = BelieverProfilesPrefix + "Update";

        /// <summary>Delete believer profile records.</summary>
        public const string BelieverProfilesDelete = BelieverProfilesPrefix + "Delete";

        /// <summary>Read creator profile records.</summary>
        public const string CreatorProfilesRead = CreatorProfilesPrefix + "Read";

        /// <summary>Create creator profile records.</summary>
        public const string CreatorProfilesCreate = CreatorProfilesPrefix + "Create";

        /// <summary>Update creator profile records.</summary>
        public const string CreatorProfilesUpdate = CreatorProfilesPrefix + "Update";

        /// <summary>Delete creator profile records.</summary>
        public const string CreatorProfilesDelete = CreatorProfilesPrefix + "Delete";

        /// <summary>Read creation records.</summary>
        public const string CreationsRead = CreationsPrefix + "Read";

        /// <summary>Create creation records.</summary>
        public const string CreationsCreate = CreationsPrefix + "Create";

        /// <summary>Update creation records.</summary>
        public const string CreationsUpdate = CreationsPrefix + "Update";

        /// <summary>Delete creation records.</summary>
        public const string CreationsDelete = CreationsPrefix + "Delete";

        /// <summary>Read contribution records.</summary>
        public const string ContributionsRead = ContributionsPrefix + "Read";

        /// <summary>Create contribution records.</summary>
        public const string ContributionsCreate = ContributionsPrefix + "Create";

        /// <summary>Update contribution records.</summary>
        public const string ContributionsUpdate = ContributionsPrefix + "Update";

        /// <summary>Delete contribution records.</summary>
        public const string ContributionsDelete = ContributionsPrefix + "Delete";

        /// <summary>Read influence relationship records.</summary>
        public const string InfluencesRead = InfluencesPrefix + "Read";

        /// <summary>Create influence relationship records.</summary>
        public const string InfluencesCreate = InfluencesPrefix + "Create";

        /// <summary>Update influence relationship records.</summary>
        public const string InfluencesUpdate = InfluencesPrefix + "Update";

        /// <summary>Delete influence relationship records.</summary>
        public const string InfluencesDelete = InfluencesPrefix + "Delete";

        /// <summary>Read discoverer profile records.</summary>
        public const string DiscovererProfilesRead = DiscovererProfilesPrefix + "Read";

        /// <summary>Create discoverer profile records.</summary>
        public const string DiscovererProfilesCreate = DiscovererProfilesPrefix + "Create";

        /// <summary>Update discoverer profile records.</summary>
        public const string DiscovererProfilesUpdate = DiscovererProfilesPrefix + "Update";

        /// <summary>Delete discoverer profile records.</summary>
        public const string DiscovererProfilesDelete = DiscovererProfilesPrefix + "Delete";

        /// <summary>Read discovery records.</summary>
        public const string DiscoveriesRead = DiscoveriesPrefix + "Read";

        /// <summary>Create discovery records.</summary>
        public const string DiscoveriesCreate = DiscoveriesPrefix + "Create";

        /// <summary>Update discovery records.</summary>
        public const string DiscoveriesUpdate = DiscoveriesPrefix + "Update";

        /// <summary>Delete discovery records.</summary>
        public const string DiscoveriesDelete = DiscoveriesPrefix + "Delete";
    }
}
