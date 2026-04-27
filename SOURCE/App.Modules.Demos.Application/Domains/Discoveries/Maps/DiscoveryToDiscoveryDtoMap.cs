using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Discoverers.Maps
{
	/// <summary>Maps Discovery to DiscoveryDto. Discovered via IObjectMap scan.</summary>
	public class DiscoveryToDiscoveryDtoMap : ObjectMapBase<Discovery, DiscoveryDto>
	{
		/// <inheritdoc/>
		protected override void ConfigureMapping()
		{
			this.CreateMap().MapFrom(dest => dest.Id, src => src.Id).MapFrom(dest => dest.DiscovererProfileId, src => src.DiscovererProfileId).MapFrom(dest => dest.Title, src => src.Title).MapFrom(dest => dest.Description, src => src.Description).MapFrom(dest => dest.Year, src => src.Year).MapFrom(dest => dest.LocationName, src => src.LocationName).MapFrom(dest => dest.Latitude, src => src.Latitude).MapFrom(dest => dest.Longitude, src => src.Longitude).MapFrom(dest => dest.Significance, src => src.Significance);
		}
	}
}
