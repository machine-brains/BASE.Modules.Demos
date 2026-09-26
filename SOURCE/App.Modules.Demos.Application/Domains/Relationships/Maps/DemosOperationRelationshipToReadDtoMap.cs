using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Relationships.Structures.Entities;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Relationships.Maps
{
    /// <summary>Explicit read projection for Demos operation relationships.</summary>
    /// <remarks>Only graph-facing business fields cross the Application boundary; persistence metadata remains infrastructure-owned.</remarks>
    public class DemosOperationRelationshipToReadDtoMap : ObjectMapBase<DemosOperationRelationship, DemosOperationRelationshipReadDto>
    {
        /// <inheritdoc />
        protected override void ConfigureMapping()
        {
            this.CreateMap()
                .MapFrom(dest => dest.Id, src => src.Id)
                .MapFrom(dest => dest.SourceExampleAId, src => src.SourceExampleAId)
                .MapFrom(dest => dest.TargetExampleAId, src => src.TargetExampleAId)
                .MapFrom(dest => dest.RelationshipKind, src => src.RelationshipKind)
                .MapFrom(dest => dest.Label, src => src.Label)
                .MapFrom(dest => dest.Description, src => src.Description)
                .MapFrom(dest => dest.IsDirected, src => src.IsDirected)
                .MapFrom(dest => dest.SortOrder, src => src.SortOrder);
        }
    }
}