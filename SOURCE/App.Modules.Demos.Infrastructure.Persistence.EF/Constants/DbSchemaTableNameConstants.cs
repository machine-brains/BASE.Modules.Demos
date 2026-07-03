namespace App.Modules.Demos.Infrastructure.Constants
{
	/// <summary>
	/// Constants for database table names within the Demos module.
	/// All table names use snake_case to follow database naming conventions.
	/// </summary>
	public static class DbSchemaTableNameConstants
	{
		/// <summary>
		/// Table name for <see cref="Domain.Domains.Discoverers.Structures.DiscovererProfile"/> entities.
		/// </summary>
		public const string DiscovererProfile = "discoverer_profile";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Creations.Structures.AtRest.Models.CreatorProfile"/> entities.
		/// </summary>
		public const string CreatorProfile = "creator_profile";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Profiles.Models.BelieverProfile"/> entities.
		/// </summary>
		public const string BelieverProfile = "believer_profile";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Discoveries.Structures.AtRest.Entities.Discovery"/> entities.
		/// </summary>
		public const string Discovery = "discovery";

        /// <summary>
        /// Table name for <see cref="Domain.Domains.Creations.Structures.AtRest.Models.Creation"/> entities.
        /// </summary>
        public const string Creation = "creation";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Contributions.Structures.AtRest.Entities.Contribution"/> entities.
		/// </summary>
		public const string Contribution = "contribution";

        /// <summary>
        /// Table name for <see cref="Domain.Domains.Influences.Structures.Entities.Influence"/> entities.
        /// </summary>
        public const string Influence = "influence";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Structures.ReferenceData.ProfileTypeReferenceData"/> reference data.
		/// </summary>
		public const string ProfileTypeReferenceData = "profile_type";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Influences.Structures.Entities.InfluenceTypeReferenceData"/> reference data.
		/// </summary>
		public const string InfluenceTypeReferenceData = "influence_type";

        /// <summary>
        /// Table name for <see cref="Domain.Domains.Influences.Structures.Entities.InfluenceStrengthReferenceData"/> reference data.
        /// </summary>
        public const string InfluenceStrengthReferenceData = "influence_strength";

        /// <summary>
        /// Table name for <see cref="Domain.Domains.Creations.Structures.AtRest.Models.CreativeMediumReferenceData"/> reference data.
        /// </summary>
        public const string CreativeMediumReferenceData = "creative_medium";
	}
}
