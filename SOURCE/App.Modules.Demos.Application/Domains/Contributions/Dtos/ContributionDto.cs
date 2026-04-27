using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Contributions.Dtos
{
/// <summary>
/// Read DTO for <see cref="Shared.Domains.Contributions.Models.Contribution"/>.
/// </summary>
public class ContributionDto : IHasGuidId
{
/// <inheritdoc/>
public Guid Id { get; set; }

/// <summary>FK to the associated BelieverProfile.</summary>
public Guid BelieverProfileId { get; set; }

/// <summary>Display title.</summary>
public string Title { get; set; } = string.Empty;

/// <summary>Optional description.</summary>
public string? Description { get; set; }

/// <summary>Year of contribution. Negative = BCE.</summary>
public int Year { get; set; }

/// <summary>Tradition name.</summary>
public string? TraditionName { get; set; }

/// <summary>Statement of significance.</summary>
public string? Significance { get; set; }
}
}
