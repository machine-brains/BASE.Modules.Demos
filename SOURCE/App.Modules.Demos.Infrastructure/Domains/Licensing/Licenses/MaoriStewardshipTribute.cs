using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Licensing.Licenses
{
	/// <summary>
	/// Personal tribute to Māori knowledge holders and communities in Aotearoa New Zealand.
	/// </summary>
	public sealed class MaoriStewardshipTribute : ITribute
	{
		public bool Enabled { get; set; } = true;
		public string Person => "Māori knowledge holders and communities in Aotearoa New Zealand";
		public string Contribution => "Stewardship, ownership, and temporal responsibility";
				public string TributeText => "I acknowledge ideas heard from Māori voices that helped me understand ownership and responsible temporal stewardship as distinct concepts. This is a personal tribute, not a claim to represent Māori perspectives.";
	}
}