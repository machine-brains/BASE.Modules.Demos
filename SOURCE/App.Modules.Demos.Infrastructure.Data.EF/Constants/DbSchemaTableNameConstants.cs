namespace App.Modules.Demos.Infrastructure.Constants
{
	/// <summary>
	/// Constants for database table names within the Demos module.
	/// All table names use snake_case to follow database naming conventions.
	/// </summary>
	public static class DbSchemaTableNameConstants
	{
		/// <summary>
		/// Table name for <see cref="Shared.Domains.Profiles.Models.DiscovererProfile"/> entities.
		/// </summary>
		public const string DiscovererProfile = "discoverer_profile";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Profiles.Models.CreatorProfile"/> entities.
		/// </summary>
		public const string CreatorProfile = "creator_profile";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Profiles.Models.BelieverProfile"/> entities.
		/// </summary>
		public const string BelieverProfile = "believer_profile";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Contributions.Models.Discovery"/> entities.
		/// </summary>
		public const string Discovery = "discovery";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Contributions.Models.Creation"/> entities.
		/// </summary>
		public const string Creation = "creation";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Contributions.Models.Contribution"/> entities.
		/// </summary>
		public const string Contribution = "contribution";

		/// <summary>
		/// Table name for <see cref="Shared.Domains.Relationships.Models.Influence"/> entities.
		/// </summary>
		public const string Influence = "influence";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.ReferenceData.Models.ProfileTypeReferenceData"/> reference data.
		/// </summary>
		public const string ProfileTypeReferenceData = "profile_type";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Influences.Models.InfluenceTypeReferenceData"/> reference data.
		/// </summary>
		public const string InfluenceTypeReferenceData = "influence_type";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Influences.Models.InfluenceStrengthReferenceData"/> reference data.
		/// </summary>
		public const string InfluenceStrengthReferenceData = "influence_strength";

		/// <summary>
		/// Table name for <see cref="Domain.Domains.Creations.Models.CreativeMediumReferenceData"/> reference data.
		/// </summary>
		public const string CreativeMediumReferenceData = "creative_medium";
	}
}
