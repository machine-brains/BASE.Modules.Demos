using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Shared.Domains.Profiles.Models
{
	/// <summary>
	/// Believer profile (Boorstin Trilogy). About a Person; PersonId is the boundary FK.
	/// </summary>
	public class BelieverProfile : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
	{
		/// <summary>Opaque boundary reference to the Person in Social module.</summary>
		public Guid PersonId { get; set; }
		/// <inheritdoc/>
		public string Title { get; set; } = string.Empty;
		/// <inheritdoc/>
		public string? Description { get; set; }
		/// <summary>Approximate start year of active era. Negative = BCE.</summary>
		public int? EraFrom { get; set; }
		/// <summary>Approximate end year of active era. Negative = BCE.</summary>
		public int? EraTo { get; set; }
		/// <summary>Name of the religious, philosophical, or ideological tradition.</summary>
		public string? TraditionName { get; set; }
		/// <summary>Nationality or cultural origin.</summary>
		public string? Nationality { get; set; }
	}
}
