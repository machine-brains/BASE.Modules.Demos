using App.Modules.Demos.Application.Domains.Believers.Dtos;
using App.Modules.Demos.Shared.Domains.Profiles.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Believers.Maps
{
	/// <summary>Maps BelieverProfile to BelieverProfileDto. Discovered via IObjectMap scan.</summary>
	public class BelieverProfileToBelieverProfileDtoMap : ObjectMapBase<BelieverProfile, BelieverProfileDto>
	{
		/// <inheritdoc/>
		protected override void ConfigureMapping()
		{
			this.CreateMap().MapFrom(dest => dest.Id, src => src.Id).MapFrom(dest => dest.PersonId, src => src.PersonId).MapFrom(dest => dest.Title, src => src.Title).MapFrom(dest => dest.Description, src => src.Description).MapFrom(dest => dest.EraFrom, src => src.EraFrom).MapFrom(dest => dest.EraTo, src => src.EraTo).MapFrom(dest => dest.TraditionName, src => src.TraditionName).MapFrom(dest => dest.Nationality, src => src.Nationality);
		}
	}
}
