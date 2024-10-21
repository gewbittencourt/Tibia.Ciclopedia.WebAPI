using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Domain.Monsters
{
	public class Monster
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public int HitPoints { get; private set; }

		public int Experience { get; private set; }

		public MonsterDifficulty DifficultyCategory { get; private set; }

		public void NewMonster()
		{
			Id = Guid.NewGuid();
		}
	}
}
