using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty
{

	public class GetMonsterByWeaknessAndDifficultyInput : IRequest<Output<IEnumerable<Monster>>>
	{

		public string Element {  get; set; }
		public MonsterDifficulty DifficultyCategory { get; set; }
	}
}
