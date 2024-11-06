using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping
{
	public class MappingMonsterCollection : Profile
	{
		public MappingMonsterCollection()
		{

			CreateMap<Monster, MonsterCollection>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.MonsterId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.ElementsWeaknessMonster, opt => opt.MapFrom(src => src.ElementsWeaknessMonster));

			CreateMap<MonsterCollection, Monster>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MonsterId))
				.ForMember(dest => dest.ElementsWeaknessMonster, opt => opt.MapFrom(src => src.ElementsWeaknessMonster));


			CreateMap<ElementsWeaknessMonsterCollectionMember, ElementsWeaknessMonster>().ReverseMap();
			CreateMap<MonsterDifficultyCollectionMember, MonsterDifficulty>().ReverseMap();

		}
	}
}
