using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Licensing.Licenses
{
	/// <summary>Personal tribute for Daniel Bennett's teaching.</summary>
	public sealed class DanielBennettTribute : ITribute
	{
		public bool Enabled { get; set; } = true;
		public string Person => "Daniel Bennett";
		public string Contribution => "GRASP, SOLID principles, and domain-driven design";
				public string TributeText => "For introducing GRASP, SOLID principles, and domain-driven design.";
	}
}