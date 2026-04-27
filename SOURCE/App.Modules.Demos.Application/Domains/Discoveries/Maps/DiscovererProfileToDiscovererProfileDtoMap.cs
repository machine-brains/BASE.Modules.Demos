using App.Modules.Demos.Application.Domains.Discoverers.Dtos;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Discoverers.Maps
{
	/// <summary>Maps DiscovererProfile to DiscovererProfileDto. Discovered via IObjectMap scan.</summary>
	public class DiscovererProfileToDiscovererProfileDtoMap : ObjectMapBase<DiscovererProfile, DiscovererProfileDto>
	{
		/// <inheritdoc/>
		protected override void ConfigureMapping()
		{
			this.CreateMap().MapFrom(dest => dest.Id, src => src.Id).MapFrom(dest => dest.PersonId, src => src.PersonId).MapFrom(dest => dest.Title, src => src.Title).MapFrom(dest => dest.Description, src => src.Description).MapFrom(dest => dest.EraFrom, src => src.EraFrom).MapFrom(dest => dest.EraTo, src => src.EraTo).MapFrom(dest => dest.FieldOfStudy, src => src.FieldOfStudy).MapFrom(dest => dest.Nationality, src => src.Nationality);
		}
	}
}
