using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Examples.Maps
{
    /// <summary>Explicit read projection from Demos ExampleB to ExampleBReadDto.</summary>
    public class ExampleBToExampleBReadDtoMap : ObjectMapBase<ExampleB, ExampleBReadDto>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            this.CreateMap()
                .MapFrom(dest => dest.Id, src => src.Id)
                .MapFrom(dest => dest.ExampleAId, src => src.ExampleAId)
                .MapFrom(dest => dest.Name, src => src.Name)
                .MapFrom(dest => dest.Description, src => src.Description)
                .MapFrom(dest => dest.SortOrder, src => src.SortOrder)
                .MapFrom(dest => dest.CreatedUtc, src => src.CreatedOnUtc)
                .MapFrom(dest => dest.FromUtc, src => src.FromUtc)
                .MapFrom(dest => dest.ToUtc, src => src.ToUtc)
                .MapFrom(dest => dest.Latitude, src => src.Latitude)
                .MapFrom(dest => dest.Longitude, src => src.Longitude);
        }
    }
}