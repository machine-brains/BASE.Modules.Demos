using App.Modules.Sys.Shared.Domains.Persistence.Models;

namespace App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos
{
    /// <summary>Read contract for explicit peer relationships between Demos operations.</summary>
    /// <remarks>
    /// The DTO carries graph semantics without embedding ExampleA records. The client joins
    /// these opaque IDs to the visible ExampleA items; it must not synthesize edges from
    /// ExampleB parent containment or from node proximity.
    /// </remarks>
    public class DemosOperationRelationshipReadDto : IHasGuidId
    {
        /// <summary>Gets or sets the relationship identity.</summary>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the source ExampleA operation identity.</summary>
        public Guid SourceExampleAId { get; set; }

        /// <summary>Gets or sets the target ExampleA operation identity.</summary>
        public Guid TargetExampleAId { get; set; }

        /// <summary>Gets or sets the domain-owned relationship kind.</summary>
        public string RelationshipKind { get; set; } = string.Empty;

        /// <summary>Gets or sets the human-readable relationship label.</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>Gets or sets the optional relationship description.</summary>
        public string? Description { get; set; }

        /// <summary>Gets or sets whether the relationship is directed.</summary>
        public bool IsDirected { get; set; }

        /// <summary>Gets or sets the stable edge order.</summary>
        public int SortOrder { get; set; }
    }
}