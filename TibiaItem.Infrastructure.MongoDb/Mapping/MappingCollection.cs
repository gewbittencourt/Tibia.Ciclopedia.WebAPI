using AutoMapper;
using TibiaItem.Domain.Entities;
using TibiaItem.Infrastructure.MongoDb.Collection;

namespace TibiaItem.Infrastructure.MongoDb.Mapping
{
	public class MappingCollection : Profile
	{
		public MappingCollection()
		{
			CreateMap<Item, ItemCollection>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.ItemID, opt => opt.MapFrom(src => src.Id));
			CreateMap<Domain.Entities.SlotsInfo, Infrastructure.MongoDb.Collection.ItemCollection.SlotsInfo>();

			CreateMap<ItemCollection, Item>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ItemID));
			CreateMap<Infrastructure.MongoDb.Collection.ItemCollection.SlotsInfo, Domain.Entities.SlotsInfo>();
		}
	}
}
