using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Acknowledgements
{
	/// <summary>Personal tribute to Helen Grove.</summary>
	public sealed class HelenGroveTribute : ITribute
	{
		/// <inheritdoc />
		public string Person => "Helen Grove";

		/// <inheritdoc />
		public string Contribution => "A life shared across 25 years, 3 continents, 3 dogs, and an amazing daughter.";

		/// <inheritdoc />
		public string TributeText => "I met her on Prince Street. 25 years, 3 continents, 3 dogs and an amazing daughter later, we're still together. Probably a lot to do with her not owning a gun or an arbalette.";

		/// <inheritdoc />
		public bool Enabled { get; set; } = true;
	}
}