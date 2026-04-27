namespace App.Modules.Demos.Domain.Domains.Creations.Models.Enums
{
	/// <summary>
	/// Identifies the primary creative medium through which
	/// a Creator or Creation contributed to civilisation.
	/// </summary>
	public enum CreativeMedium
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
		/// Written works including prose, poetry,
		/// drama, and non-fiction.
		/// </summary>
		Literature = 4,

		/// <summary>
		/// Painting, sculpture, printmaking,
		/// and other visual art forms.
		/// </summary>
		VisualArt = 5,

		/// <summary>
		/// Composition, performance, and musical
		/// theory across all traditions.
		/// </summary>
		Music = 6,

		/// <summary>
		/// Design and construction of buildings,
		/// monuments, and planned spaces.
		/// </summary>
		Architecture = 7,

		/// <summary>
		/// Empirical inquiry, experimentation,
		/// and systematic knowledge production.
		/// </summary>
		Science = 8,

		/// <summary>
		/// Applied invention, engineering,
		/// and tool-making for practical ends.
		/// </summary>
		Technology = 9,

		/// <summary>
		/// Systems of thought, ethics, logic,
		/// and metaphysical inquiry.
		/// </summary>
		Philosophy = 10
	}
}
