namespace App.Modules.Demos.Infrastructure.Constants
{
    /// <summary>
    /// Constants for database schema names within the Demos module.
    /// Each sub-schema groups related tables by domain concern.
    /// </summary>
    public static class DbSchemaSchemaNameConstants
    {
        /// <summary>
        /// The root schema name for the Demos module,
        /// derived from the module's database schema key.
        /// </summary>
        public const string Root = App.Modules.Demos.ModuleConstants.DbSchemaKey;

        /// <summary>
        /// Schema name for profile-related tables
        /// (Discoverer, Creator, Believer).
        /// </summary>
        public const string Profiles = Root + "_profiles";

        /// <summary>
        /// Schema name for contribution-related tables
        /// (Discovery, Creation, Contribution).
        /// </summary>
        public const string Contributions = Root + "_contributions";

        /// <summary>
        /// Schema name for relationship-related tables
        /// (Influence).
        /// </summary>
        public const string Relationships = Root + "_relationships";

        /// <summary>
        /// Schema name for reference data tables.
        /// </summary>
        public const string ReferenceData = Root + "_ref";
    }
}
