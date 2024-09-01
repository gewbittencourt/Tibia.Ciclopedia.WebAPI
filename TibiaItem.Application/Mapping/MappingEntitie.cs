using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Application.UseCases.CreateItem;
using TibiaItem.Domain.Entities;

namespace TibiaItem.Application.Mapping
{
	public class MappingEntitie : Profile
	{

		public MappingEntitie()
		{
			// Mapeamento de CreateItemRequest para Item
			CreateMap<CreateItemInput, Item>()
				.ForMember(dest => dest.Slots, opt => opt.MapFrom(src => src.Slots))
				.AfterMap((src, dest) => dest.NewItem());

			// Mapeamento de SlotsInfo (de Application.Handlers para Domain.Entities)
			CreateMap<UseCases.CreateItem.SlotsInfo, Domain.Entities.SlotsInfo>();
		}
	}
}
