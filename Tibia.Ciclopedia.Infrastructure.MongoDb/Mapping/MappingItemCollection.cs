using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using AutoMapper;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping
{
	public class MappingItemCollection : Profile
	{
		public MappingItemCollection()
		{
			CreateMap<Item, ItemCollection>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
				.ForMember(dest => dest.Slots, opt => opt.MapFrom(src => src.Slots));

			CreateMap<ItemCollection, Item>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemID))
				.ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
				.ForMember(dest => dest.Slots, opt => opt.MapFrom(src => src.Slots));

			CreateMap<PeriodControl, PeriodControlCollectionMember>().ReverseMap();
			CreateMap<SlotsInfoItem, SlotsInfoItemCollectionMember>().ReverseMap();

		}
	}
}
