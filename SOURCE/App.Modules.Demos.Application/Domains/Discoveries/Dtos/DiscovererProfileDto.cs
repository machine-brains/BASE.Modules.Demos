using App.Modules.Sys.Shared.Models.Persistence;

namespace App.Modules.Demos.Application.Domains.Discoverers.Dtos
{
/// <summary>
/// Read DTO for <see cref="Shared.Domains.Profiles.Models.DiscovererProfile"/>.
/// </summary>
public class DiscovererProfileDto : IHasGuidId
{
/// <inheritdoc/>
public Guid Id { get; set; }

/// <summary>Boundary reference to the associated Person.</summary>
public Guid PersonId { get; set; }

/// <summary>Display title.</summary>
public string Title { get; set; } = string.Empty;

/// <summary>Optional description.</summary>
public string? Description { get; set; }

/// <summary>Approximate start year of active era. Negative = BCE.</summary>
public int? EraFrom { get; set; }

/// <summary>Approximate end year of active era. Negative = BCE.</summary>
public int? EraTo { get; set; }

/// <summary>Primary field of study or discipline.</summary>
public string? FieldOfStudy { get; set; }

/// <summary>Nationality or cultural origin.</summary>
public string? Nationality { get; set; }
}
}
