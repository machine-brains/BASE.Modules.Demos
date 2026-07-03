using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Domain.Domains.Structures.ReferenceData
{
    /// <summary>
    /// Reference data entity representing a profile type within the Boorstin Trilogy
    /// classification (Discoverer, Creator, Believer).
    /// <para>
    /// Converts the <see cref="ProfileType"/> enum into a reference data table so that
    /// referential integrity can be enforced at the database level and UX can display
    /// profile type labels dynamically.
    /// </para>
    /// <para>
    /// <b>Deterministic GUIDs:</b> System-seeded entries use GUIDs derived from the enum
    /// integer value via <c>DeterministicGuid.FromEnum</c>.
    /// </para>
    /// </summary>
    public class ProfileTypeReferenceData : DefaultReferenceDataEntityBase
    {
        /// <summary>
        /// The integer value from the <see cref="ProfileType"/> enum.
        /// <para>
        /// For system-seeded records, this matches the enum value exactly.
        /// </para>
        /// </summary>
        public int? EnumValue { get; set; }
    }
}
