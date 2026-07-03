using App.Modules.Sys.Shared.Models;
using App.Modules.Sys.Shared.Models.Base;

namespace App.Modules.Demos.Domain.Domains.Discoverers.Structures
{
/// <summary>
/// Represents a Discoverer profile — one who expands the boundaries
/// of knowledge through exploration and inquiry, as described in
/// Daniel J. Boorstin's <em>The Discoverers</em>.
/// </summary>
/// <remarks>
/// A profile is a bounded-context record about a historical person.
/// <see cref="PersonId"/> references the Person aggregate in the
/// Identity/Social module but carries no navigation property,
/// keeping this module's schema independent of those tables.
/// </remarks>
public class DiscovererProfile : DefaultEntityBase, IHasTitle, IHasDescriptionNullable
{
/// <summary>
/// Gets or sets the identifier of the associated Person record in the
/// Identity module. Boundary reference — no navigation property.
/// </summary>
public Guid PersonId { get; set; }

/// <summary>
/// Gets or sets the display title, typically the person's
/// full name or known historical name.
/// </summary>
public string Title { get; set; } = string.Empty;

/// <summary>
/// Gets or sets an optional biographical summary.
/// </summary>
public string? Description { get; set; }

/// <summary>
/// Gets or sets the approximate start year of the era in which
/// this person was active (negative for BCE).
/// </summary>
public int? EraFrom { get; set; }

/// <summary>
/// Gets or sets the approximate end year of the era in which
/// this person was active (negative for BCE).
/// </summary>
public int? EraTo { get; set; }

/// <summary>
/// Gets or sets the primary field of study or area of discovery.
/// </summary>
public string? FieldOfStudy { get; set; }

/// <summary>
/// Gets or sets the nationality or cultural origin.
/// </summary>
public string? Nationality { get; set; }
}
}
