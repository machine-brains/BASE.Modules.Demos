using App.Modules.Demos.Application.Domains.Relationships.Structures.InTransit.Dtos;
using App.Modules.Demos.Domain.Domains.Influences.Structures.Entities;
using App.Modules.Sys.Shared.ObjectMaps.Models.Implementations.Base;

namespace App.Modules.Demos.Application.Domains.Relationships.Maps
{
	/// <summary>Maps Influence to InfluenceReadDto. Discovered via IObjectMap scan.</summary>
	public class InfluenceToInfluenceDtoMap : ObjectMapBase<Influence, InfluenceReadDto>
	{
		/// <inheritdoc/>
		protected override void ConfigureMapping()
		{
			this.CreateMap().MapFrom(dest => dest.Id, src => src.Id).MapFrom(dest => dest.InfluencerProfileId, src => src.InfluencerProfileId).MapFrom(dest => dest.InfluencerProfileTypeId, src => src.InfluencerProfileTypeId).MapFrom(dest => dest.InfluencedProfileId, src => src.InfluencedProfileId).MapFrom(dest => dest.InfluencedProfileTypeId, src => src.InfluencedProfileTypeId).MapFrom(dest => dest.Description, src => src.Description).MapFrom(dest => dest.InfluenceTypeId, src => src.InfluenceTypeId).MapFrom(dest => dest.InfluenceStrengthId, src => src.InfluenceStrengthId);
		}
	}
}
