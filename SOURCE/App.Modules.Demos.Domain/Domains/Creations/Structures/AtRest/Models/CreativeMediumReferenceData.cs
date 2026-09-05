using App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Enums;
using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;

namespace App.Modules.Demos.Domain.Domains.Creations.Structures.AtRest.Models
{
    /// <summary>
    /// Reference data entity representing a creative medium
    /// (Literature, VisualArt, Music, Architecture, Science, Technology, Philosophy).
    /// <para>
    /// Converts the <see cref="CreativeMedium"/> enum into a reference data table so that
    /// referential integrity can be enforced at the database level and UX can display
    /// medium labels dynamically.
    /// </para>
    /// <para>
    /// <b>Deterministic GUIDs:</b> System-seeded entries use GUIDs derived from the enum
    /// integer value via <c>DeterministicGuid.FromEnum</c>.
    /// </para>
    /// </summary>
    public class CreativeMediumReferenceData : DefaultReferenceDataEntityBase
    {
        /// <summary>
        /// The integer value from the <see cref="CreativeMedium"/> enum.
        /// <para>
        /// For system-seeded records, this matches the enum value exactly.
        /// </para>
        /// </summary>
        public int? EnumValue { get; set; }
    }
}
