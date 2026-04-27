using App.Modules.Demos.Application.Domains.Creators.Dtos;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Creators.Maps
{
    /// <summary>Maps CreationDto to Creation (for create/update operations). Discovered via IObjectMap scan.</summary>
    public class CreationDtoToCreationMap : ObjectMapBase<CreationDto, Creation>
    {
        /// <inheritdoc/>
        protected override void ConfigureMapping()
        {
            this.CreateMap()
                .MapFrom(dest => dest.Id, src => src.Id)
                .MapFrom(dest => dest.CreatorProfileId, src => src.CreatorProfileId)
                .MapFrom(dest => dest.Title, src => src.Title)
                .MapFrom(dest => dest.Description, src => src.Description)
                .MapFrom(dest => dest.Year, src => src.Year)
                .MapFrom(dest => dest.CreativeMediumId, src => src.CreativeMediumId)
                .MapFrom(dest => dest.Genre, src => src.Genre)
                .MapFrom(dest => dest.Significance, src => src.Significance);
        }
    }
}
