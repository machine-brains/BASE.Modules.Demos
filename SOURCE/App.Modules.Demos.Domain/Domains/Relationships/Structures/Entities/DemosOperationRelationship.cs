using App.Modules.Sys.Shared.Domains.Persistence.Models.Implementations.Base;
using App.Modules.Sys.Shared.Domains.Persistence.Models;
using App.Modules.Sys.Substrate.Domains.Models;

namespace App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities
{
    /// <summary>
    /// Explicit peer relationship between two Demos ExampleA operation records.
    /// </summary>
    /// <remarks>
    /// The relationship is a separate aggregate with opaque source and target IDs.
    /// The Demos Application projects it into graph edges alongside ExampleA read DTOs;
    /// it must not be inferred from ExampleB containment or represented by EF navigation
    /// properties. Workspace scope belongs to this record and is enforced by the governed
    /// repository path.
    /// </remarks>
    #pragma warning disable BASE0001
    public class DemosOperationRelationship : DefaultEntityBase, IHasDescriptionNullable, IHasWorkspaceFK
    {
        /// <summary>Gets or sets the workspace that owns this relationship.</summary>
        public Guid WorkspaceFK { get; set; }

        /// <summary>Gets or sets the opaque identifier of the source ExampleA operation.</summary>
        public Guid SourceExampleAId { get; set; }

        /// <summary>Gets or sets the opaque identifier of the target ExampleA operation.</summary>
        public Guid TargetExampleAId { get; set; }

        /// <summary>Gets or sets the domain-owned relationship kind.</summary>
        public string RelationshipKind { get; set; } = string.Empty;

        /// <summary>Gets or sets the human-readable relationship label.</summary>
        public string Label { get; set; } = string.Empty;

        /// <inheritdoc />
        public string? Description { get; set; }

        /// <summary>Gets or sets whether the edge has a source-to-target direction.</summary>
        public bool IsDirected { get; set; }

        /// <summary>Gets or sets the stable display order among related edges.</summary>
        public int SortOrder { get; set; }
    }
    #pragma warning restore BASE0001
}