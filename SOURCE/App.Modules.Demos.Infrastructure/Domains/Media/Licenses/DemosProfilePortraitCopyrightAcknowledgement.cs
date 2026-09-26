using System;
using System.Collections.Generic;
using System.Linq;
using App.Modules.Sys.Shared.Domains.Licencing;

namespace App.Modules.Demos.Infrastructure.Domains.Media.Licenses
{
	/// <summary>
	/// Discoverable copyright notice for the Wikimedia Commons portraits used by Demos profiles.
	/// </summary>
	/// <remarks>
	/// This notice is separate from a general <see cref="IAcknowledgement"/> because its
	/// purpose is to preserve work-level copyright evidence. The portrait seeder consumes
	/// the same <see cref="DemosPortraitCatalog"/> entries to create MediaContent and link
	/// profile records; the notice owns neither storage nor profile state. The linked Commons
	/// file page remains the source of truth for each work's current licence.
	/// </remarks>
	public sealed class DemosProfilePortraitCopyrightAcknowledgement : ICopyrightAcknowledgement
	{
		private const string CommonsLicenseReference = "https://commons.wikimedia.org/wiki/Commons:Licensing";

		/// <inheritdoc />
		public bool Enabled { get; set; } = true;

		/// <inheritdoc />
		public string Name => "Demos profile portraits";

		/// <inheritdoc />
		public string Provider => "Wikimedia Commons contributors and source institutions";

		/// <inheritdoc />
		public string Use => "Square profile portrait crops for the Demos Discoverers, Creators, and Believers surfaces.";

		/// <inheritdoc />
		public IReadOnlyList<CopyrightWork> Works { get; } = CreateWorks();

		private static List<CopyrightWork> CreateWorks()
		{
			return DemosPortraitCatalog.Entries
				.OrderBy(entry => entry.Key, StringComparer.OrdinalIgnoreCase)
				.Select(entry => new CopyrightWork
				{
					AssetKey = entry.Value.AssetKey,
					WorkTitle = entry.Key,
					SourcePageUri = new Uri(entry.Value.AttributionUrl),
					DirectAssetUri = new Uri(entry.Value.SourceUrl),
					LicenseUri = new Uri(CommonsLicenseReference),
					RightsStatement = "The applicable rights statement is published on the linked Wikimedia Commons file page and must be verified before redistribution.",
					AttributionText = $"Source image for the {entry.Key} Demos profile: Wikimedia Commons file page at {entry.Value.AttributionUrl}.",
				})
				.ToList();
		}
	}
}