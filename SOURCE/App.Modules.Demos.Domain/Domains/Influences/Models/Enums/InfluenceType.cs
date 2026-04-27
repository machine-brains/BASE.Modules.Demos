namespace App.Modules.Demos.Domain.Domains.Influences.Models.Enums
{
	/// <summary>
	/// Categorises the nature of influence one historical
	/// figure exerted upon another.
	/// </summary>
	public enum InfluenceType
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
		/// Direct personal influence through mentorship,
		/// collaboration, or immediate contact.
		/// </summary>
		Direct = 4,

		/// <summary>
		/// Indirect influence through works, writings,
		/// or cultural legacy rather than personal contact.
		/// </summary>
		Indirect = 5,

		/// <summary>
		/// Influence through ideas, theories,
		/// or intellectual frameworks.
		/// </summary>
		Intellectual = 6,

		/// <summary>
		/// Influence through religious thought,
		/// mysticism, or faith traditions.
		/// </summary>
		Spiritual = 7,

		/// <summary>
		/// Influence through creative expression
		/// in visual, literary, or performing arts.
		/// </summary>
		Artistic = 8,

		/// <summary>
		/// Influence through empirical discovery,
		/// experimentation, or technological innovation.
		/// </summary>
		Scientific = 9,

		/// <summary>
		/// Influence through systems of thought,
		/// ethics, logic, or metaphysics.
		/// </summary>
		Philosophical = 10
	}
}
