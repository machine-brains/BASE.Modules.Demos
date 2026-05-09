using App.Modules.Demos.Application.Domains.Contributions.Dtos;
using App.Modules.Demos.Shared.Domains.Contributions.Models;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Contributions.Maps
{
	/// <summary>Maps Contribution to ContributionReadDto. Discovered via IObjectMap scan.</summary>
	public class ContributionToContributionDtoMap : ObjectMapBase<Contribution, ContributionReadDto>
	{
		/// <inheritdoc/>
		protected override void ConfigureMapping()
		{
			this.CreateMap().MapFrom(dest => dest.Id, src => src.Id).MapFrom(dest => dest.BelieverProfileId, src => src.BelieverProfileId).MapFrom(dest => dest.Title, src => src.Title).MapFrom(dest => dest.Description, src => src.Description).MapFrom(dest => dest.Year, src => src.Year).MapFrom(dest => dest.TraditionName, src => src.TraditionName).MapFrom(dest => dest.Significance, src => src.Significance);
		}
	}
}
