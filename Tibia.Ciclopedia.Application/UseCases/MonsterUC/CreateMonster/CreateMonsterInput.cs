using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster
{
	public class CreateMonsterInput : IRequest<Output<Guid>>
	{
		public string Name { get; set; }
		public int HitPoints { get; set; }
		public int Experience { get; set; }
		public MonsterDifficulty DifficultyCategory { get; set; }
		public ElementsWeaknessMonster ElementsWeaknessMonster { get; set; }
	}
}
