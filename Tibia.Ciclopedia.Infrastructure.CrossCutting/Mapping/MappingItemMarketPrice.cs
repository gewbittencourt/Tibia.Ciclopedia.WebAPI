using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.DTO;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting.Mapping
{
    public class MappingItemMarketPrice : Profile
	{
		public MappingItemMarketPrice()
		{
			CreateMap<GetPricingResponse, ItemMarketPrice>()
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
		}
	}
}
