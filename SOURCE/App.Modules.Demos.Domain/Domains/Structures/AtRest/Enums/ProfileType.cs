namespace App.Modules.Demos.Domain.Domains.Structures.ReferenceData
{
	/// <summary>
	/// Identifies the category of historical profile
	/// within the Boorstin Trilogy classification.
	/// </summary>
	public enum ProfileType
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
		/// A Discoverer — one who expands the boundaries
		/// of knowledge through exploration and inquiry.
		/// </summary>
		Discoverer = 4,

		/// <summary>
		/// A Creator — one who produces enduring works
		/// of art, literature, music, or architecture.
		/// </summary>
		Creator = 5,

		/// <summary>
		/// A Believer — one who shapes civilisation through
		/// faith, philosophy, or ideological vision.
		/// </summary>
		Believer = 6
	}
}
