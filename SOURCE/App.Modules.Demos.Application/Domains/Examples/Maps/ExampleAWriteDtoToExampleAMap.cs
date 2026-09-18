using App.Modules.Demos.Application.Domains.Examples.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Examples.Structures.AtRest.Entities;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Examples.Maps
{
    /// <summary>Explicit write projection from ExampleAWriteDto to the Demos entity.</summary>
    /// <remarks>Only caller-owned business fields are mapped; persistence metadata remains infrastructure-managed.</remarks>
    public class ExampleAWriteDtoToExampleAMap : ObjectMapBase<ExampleAWriteDto, ExampleA>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            this.CreateMap()
                .MapFrom(dest => dest.Id, src => src.Id)
                .MapFrom(dest => dest.Title, src => src.Title)
                .MapFrom(dest => dest.Description, src => src.Description)
                .MapFrom(dest => dest.IsActive, src => src.IsActive)
                .MapFrom(dest => dest.FromUtc, src => src.FromUtc)
                .MapFrom(dest => dest.ToUtc, src => src.ToUtc)
                .MapFrom(dest => dest.Latitude, src => src.Latitude)
                .MapFrom(dest => dest.Longitude, src => src.Longitude);
        }
    }
}