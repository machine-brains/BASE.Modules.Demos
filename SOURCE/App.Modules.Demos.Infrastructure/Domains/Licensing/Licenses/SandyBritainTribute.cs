using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Licensing.Licenses
{
	/// <summary>Personal tribute for Sandy Britain's teaching.</summary>
	public sealed class SandyBritainTribute : ITribute
	{
		public bool Enabled { get; set; } = true;
		public string Person => "Sandy Britain";
		public string Contribution => "Values and Principles and Continuums";
				public string TributeText => "For introducing Values and Principles and Continuums.";
	}
}