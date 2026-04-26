namespace App.Modules.Demos.Infrastructure.Constants
{
    /// <summary>
    /// Database schema name constants for organizing tables into logical groups.
    /// </summary>
    public static class DbSchemaSchemaNameConstants
    {
        /// <summary>
        /// Default schema for this module (same as module key).
        /// </summary>
        public const string Root = App.Modules.Demos.ModuleConstants.DbSchemaKey;

        /// <summary>
        /// Schema for reference/lookup data tables.
        /// </summary>
        public const string Examples = Root + "_examples";


    }
}