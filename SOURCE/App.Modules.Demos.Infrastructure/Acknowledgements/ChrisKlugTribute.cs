using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Acknowledgements
{
	/// <summary>Personal tribute to Chris and Hanna Klug.</summary>
	public sealed class ChrisAndHannaKlugTribute : ITribute
	{
		/// <inheritdoc />
		public string Person => "Chris & Hanna Klug";

		/// <inheritdoc />
		public string Contribution => "True friends. Co-seeker.";

		/// <inheritdoc />
		public string TributeText => "Svenskt stål biter bäst.";

		/// <inheritdoc />
		public bool Enabled { get; set; } = true;
	}
}