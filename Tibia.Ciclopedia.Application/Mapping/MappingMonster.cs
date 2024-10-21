using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.Mapping
{
	public class MappingMonster : Profile
	{
		public MappingMonster()
		{

			CreateMap<CreateMonsterInput, Monster>().AfterMap((src, dest) => dest.NewMonster()); ;

		}
	}
}
