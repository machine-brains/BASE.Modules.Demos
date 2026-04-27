using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Discoverers.Dtos
{
/// <summary>
/// Read DTO for <see cref="Shared.Domains.Contributions.Models.Discovery"/>.
/// </summary>
public class DiscoveryDto : IHasGuidId
{
/// <inheritdoc/>
public Guid Id { get; set; }

/// <summary>FK to the associated DiscovererProfile.</summary>
public Guid DiscovererProfileId { get; set; }

/// <summary>Display title.</summary>
public string Title { get; set; } = string.Empty;

/// <summary>Optional description.</summary>
public string? Description { get; set; }

/// <summary>Year of discovery. Negative = BCE.</summary>
public int Year { get; set; }

/// <summary>Name of the discovery location.</summary>
public string? LocationName { get; set; }

/// <summary>Latitude coordinate.</summary>
public double? Latitude { get; set; }

/// <summary>Longitude coordinate.</summary>
public double? Longitude { get; set; }

/// <summary>Statement of significance.</summary>
public string? Significance { get; set; }
}
}
