using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Shared.Domains.Contributions.Models
{
/// <summary>
/// A specific contribution made by a BelieverProfile.
/// Captures the act of faith, philosophical insight,
/// or ideological initiative and its significance.
/// </summary>
public class Contribution : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
{
/// <summary>Boundary FK to the BelieverProfile that made this contribution.</summary>
public Guid BelieverProfileId { get; set; }

/// <inheritdoc/>
public string Title { get; set; } = string.Empty;

/// <inheritdoc/>
public string? Description { get; set; }

/// <summary>Year of contribution. Negative = BCE.</summary>
public int Year { get; set; }

/// <summary>Name of the tradition associated with this contribution.</summary>
public string? TraditionName { get; set; }

/// <summary>Statement of historical or cultural significance.</summary>
public string? Significance { get; set; }
}
}
