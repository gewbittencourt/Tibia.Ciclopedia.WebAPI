using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
