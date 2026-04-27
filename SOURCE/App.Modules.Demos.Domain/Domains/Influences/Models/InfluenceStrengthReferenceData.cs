using App.Modules.Demos.Domain.Domains.Influences.Models.Enums;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Domain.Domains.Influences.Models
{
    /// <summary>
    /// Reference data entity representing the magnitude of an influence relationship
    /// (Minor, Moderate, Major, Transformative).
    /// <para>
    /// Converts the <see cref="InfluenceStrength"/> enum into a reference data table so that
    /// referential integrity can be enforced at the database level and UX can display
    /// strength labels dynamically.
    /// </para>
    /// <para>
    /// <b>Deterministic GUIDs:</b> System-seeded entries use GUIDs derived from the enum
    /// integer value via <c>DeterministicGuid.FromEnum</c>.
    /// </para>
    /// </summary>
    public class InfluenceStrengthReferenceData : DefaultReferenceDataEntityBase
    {
        /// <summary>
        /// The integer value from the <see cref="InfluenceStrength"/> enum.
        /// <para>
        /// For system-seeded records, this matches the enum value exactly.
        /// </para>
        /// </summary>
        public int? EnumValue { get; set; }
    }
}
