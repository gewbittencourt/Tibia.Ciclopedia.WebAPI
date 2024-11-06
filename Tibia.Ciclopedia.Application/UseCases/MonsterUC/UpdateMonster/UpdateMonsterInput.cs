using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.UpdateMonster
{
	public class UpdateMonsterInput : IRequest<Output<bool>>
	{
		[JsonIgnore]
		public Guid Id { get; set; }

		public string? Name { get;  set; }

		public int? HitPoints { get;  set; }

		public int? Experience { get;  set; }

		public MonsterDifficulty? DifficultyCategory { get;  set; }

		public ElementsWeaknessMonster? ElementsWeaknessMonster { get; set; }
	}
}
