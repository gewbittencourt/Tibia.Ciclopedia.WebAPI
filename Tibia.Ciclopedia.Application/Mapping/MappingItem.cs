using AutoMapper;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Domain.Items;


namespace Tibia.Ciclopedia.Application.Mapping
{
    public class MappingItem : Profile
	{

		public MappingItem()
		{
			// Mapeamento de CreateItemRequest para Item
			CreateMap<CreateItemInput, Item>()
				.ForMember(dest => dest.Slots, opt => opt.MapFrom(src => src.Slots))
				.AfterMap((src, dest) => dest.NewItem());
		}
	}
}
