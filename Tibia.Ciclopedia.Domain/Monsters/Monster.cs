using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.Enums;
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


		public void UpdateMonster(string? name, int? hitPoints, int? experience, MonsterDifficulty? difficultyCategory)
		{
			if (!string.IsNullOrEmpty(name))
			{
				Name = name;
			}
			if (hitPoints.HasValue)
				HitPoints = (int)hitPoints;

			if (experience.HasValue)
				Experience = (int)experience;

			if (difficultyCategory.HasValue)
				DifficultyCategory = (MonsterDifficulty)difficultyCategory;
		}

	}
}
