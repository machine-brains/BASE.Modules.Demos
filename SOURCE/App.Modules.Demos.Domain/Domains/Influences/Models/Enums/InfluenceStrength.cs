namespace App.Modules.Demos.Domain.Domains.Influences.Models.Enums
{
	/// <summary>
	/// Quantifies the magnitude of influence one historical
	/// figure had upon another.
	/// </summary>
	public enum InfluenceStrength
	{
		/// <summary>
		/// The value has not been set.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// The value is not applicable in this context.
		/// </summary>
		NotApplicable = 1,

		/// <summary>
		/// The value was not specified by the user.
		/// </summary>
		Unspecified = 2,

		/// <summary>
		/// The value is not known.
		/// </summary>
		Unknown = 3,

		/// <summary>
		/// A minor influence with limited or localised impact.
		/// </summary>
		Minor = 4,

		/// <summary>
		/// A moderate influence with noticeable
		/// but bounded effect.
		/// </summary>
		Moderate = 5,

		/// <summary>
		/// A major influence with broad and
		/// lasting significance.
		/// </summary>
		Major = 6,

		/// <summary>
		/// A transformative influence that fundamentally
		/// reshaped a field, tradition, or civilisation.
		/// </summary>
		Transformative = 7
	}
}
