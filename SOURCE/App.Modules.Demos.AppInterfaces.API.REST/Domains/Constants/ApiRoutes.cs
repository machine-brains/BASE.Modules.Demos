using App.Modules.Sys.AccessControl.Constants;
using App.Modules.Sys.Shared.Domains.AccessControl.Constants;
using App.Modules.Sys.Shared.Domains.Configuration.Constants;

using App.Modules.Sys.Shared.Domains.Presentation.Constants;

namespace App.Modules.Demos.Interfaces.API.REST.Domains.Constants
{
    /// <summary>
    /// Demos module API route constants.
    /// NO MAGIC STRINGS — all routes composed from constants.
    /// Organized by: {root}/{api-type}/{module}/{version}/{path}.
    /// </summary>
    /// <remarks>
    /// Pattern: api/rest/demos/v1/{controller-path}.
    /// Built on shared <see cref="ApiConstants"/> from Substrate.
    /// </remarks>
    public static class ApiRoutes
    {
        private const string ModuleId = App.Modules.Demos.ModuleConstants.Key;

        private const string RestModuleBase = ApiConstants.RestPrefix + ModuleId;

        /// <summary>
        /// REST API routes for the Demos module.
        /// </summary>
        public static class Rest
        {
            /// <summary>
            /// Version 1 routes.
            /// </summary>
            public static class V1
            {
                internal const string VersionBase = RestModuleBase + ApiConstants.RouteSeparator + ApiConstants.Versions.V1;

                /// <summary>
                /// Standard controller route template for the Demos module.
                /// Format: <c>api/rest/demos/v1/{controller}</c>.
                /// </summary>
                public const string ControllerRoute = VersionBase + "/{controller}";

                /// <summary>
                /// DiscovererProfile endpoint routes.
                /// </summary>
                public static class DiscovererProfiles
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/discoverer-profiles</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/discoverer-profiles";

                    /// <summary>
                    /// Gets the relative route for profiles belonging to a person.
                    /// </summary>
                    public const string ByPerson = "by-person/{personId:guid}";
                }

                /// <summary>
                /// CreatorProfile endpoint routes.
                /// </summary>
                public static class CreatorProfiles
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/creator-profiles</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/creator-profiles";

                    /// <summary>
                    /// Gets the relative route for profiles belonging to a person.
                    /// </summary>
                    public const string ByPerson = "by-person/{personId:guid}";
                }

                /// <summary>
                /// BelieverProfile endpoint routes.
                /// </summary>
                public static class BelieverProfiles
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/believer-profiles</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/believer-profiles";

                    /// <summary>
                    /// Gets the relative route for profiles belonging to a person.
                    /// </summary>
                    public const string ByPerson = "by-person/{personId:guid}";
                }

                /// <summary>
                /// Discovery endpoint routes.
                /// </summary>
                public static class Discoveries
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/discoveries</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/discoveries";

                    /// <summary>
                    /// Gets the relative route for discoveries belonging to a profile.
                    /// </summary>
                    public const string ByProfile = "by-profile/{profileId:guid}";
                }

                /// <summary>
                /// Creation endpoint routes.
                /// </summary>
                public static class Creations
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/creations</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/creations";

                    /// <summary>
                    /// Gets the relative route for creations belonging to a profile.
                    /// </summary>
                    public const string ByProfile = "by-profile/{profileId:guid}";
                }

                /// <summary>
                /// Contribution endpoint routes.
                /// </summary>
                public static class Contributions
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/contributions</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/contributions";

                    /// <summary>
                    /// Gets the relative route for contributions belonging to a profile.
                    /// </summary>
                    public const string ByProfile = "by-profile/{profileId:guid}";
                }

                /// <summary>
                /// Influence endpoint routes.
                /// </summary>
                public static class Influences
                {
                    /// <summary>
                    /// Base path: <c>api/rest/demos/v1/influences</c>.
                    /// </summary>
                    public const string Base = VersionBase + "/influences";

                    /// <summary>
                    /// Gets the relative route for relationships by influencing profile.
                    /// </summary>
                    public const string ByInfluencer = "by-influencer/{profileId:guid}";

                    /// <summary>
                    /// Gets the relative route for relationships by influenced profile.
                    /// </summary>
                    public const string ByInfluenced = "by-influenced/{profileId:guid}";
                }
            }
        }
    }
}
