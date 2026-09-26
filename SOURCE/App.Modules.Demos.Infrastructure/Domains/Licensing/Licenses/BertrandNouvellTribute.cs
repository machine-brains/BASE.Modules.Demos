using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Licensing.Licenses
{
	/// <summary>Personal tribute for Bertrand (Tranx) Nouvel's teaching.</summary>
	public sealed class BertrandNouvelTribute : ITribute
	{
		public bool Enabled { get; set; } = true;
		public string Person => "Bertrand (Tranx) Nouvel";
		public string Contribution => "Using proofs before coding";
				public string TributeText => "For introducing the practice of using proofs before coding.";
	}
}