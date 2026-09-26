using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Acknowledgements
{
	/// <summary>Personal tribute to Oliver Blanc.</summary>
	public sealed class OliverBlancTribute : ITribute
	{
		/// <inheritdoc />
		public string Person => "Oliver Blanc";

		/// <inheritdoc />
		public string Contribution => "Believing in this kind of work from the very start.";

		/// <inheritdoc />
		public string TributeText => "A Frenchman through and through. I have more than 20 years of humble gratitude for your belief. Merci, mon ami.";

		/// <inheritdoc />
		public bool Enabled { get; set; } = true;
	}
}