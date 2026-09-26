using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Sys.Shared.Domains.Application;

namespace App.Modules.Demos.Application.Domains.Relationships.Services
{
    /// <summary>Read Application boundary for explicit Demos operation relationships.</summary>
    /// <remarks>It exposes projected relationship records through the governed repository and leaves graph rendering policy to the client Presenter.</remarks>
    public interface IDemosOperationRelationshipApplicationService : IReadAppService<DemosOperationRelationshipReadDto>
    {
        /// <summary>Queries relationships whose source is the specified ExampleA operation.</summary>
        IQueryable<DemosOperationRelationshipReadDto> QueryBySource(Guid exampleAId);

        /// <summary>Queries relationships whose target is the specified ExampleA operation.</summary>
        IQueryable<DemosOperationRelationshipReadDto> QueryByTarget(Guid exampleAId);
    }
}