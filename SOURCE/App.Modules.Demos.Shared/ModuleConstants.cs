using App.Modules.Sys.Infrastructure.Domains.Constants;

namespace App.Modules.Demos
{
	/// <summary>
	/// Constants for the Demos module configuration.
	/// </summary>
	public class ModuleConstants
	{
		/// <summary>
		/// Unique displayable Name to identify this logical module.
		/// </summary>
		public const string Name = "Demos";

		/// <summary>
		/// Unique Lowercase Key to use as name for DbSchema
		/// and api route fragment for this Logical Module.
		/// </summary>
		public const string Key = "demos";

		/// <summary>
		/// Database schema key for this module.
		/// Used as the default schema prefix in EF configurations.
		/// </summary>
		public const string DbSchemaKey = Key;

		/// <summary>
		/// The display name of the module.
		/// </summary>
		public const string Title = Name;

		/// <summary>
		/// The description of the module.
		/// </summary>
		public const string Description = "Boorstin Trilogy Demo ÔÇö Discoverers, Creators, Believers.";

		/// <summary>
		/// The name of the ConnectionString in app settings.
		/// </summary>
		public const string DbConnectionName = AppConstants.DbConnectionStringKey;
	}
}
