using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.UpdateMonster;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTest.UpdateMonsterTests
{
	public class UpdateMonsterInputTests
	{
		[Fact]
		public void UpdateMonsterInput_ShouldSetPropertiesCorrectly()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var name = "Dragon";
			var hitPoints = 5000;
			var experience = 1000;
			var difficultyCategory = MonsterDifficulty.Medium;
			var elementsWeaknessMonster = new ElementsWeaknessMonster(100,100,100,100,100,100,100);

			// Act
			var input = new UpdateMonsterInput
			{
				Id = monsterId,
				Name = name,
				HitPoints = hitPoints,
				Experience = experience,
				DifficultyCategory = difficultyCategory,
				ElementsWeaknessMonster = elementsWeaknessMonster
			};

			// Assert
			Assert.Equal(monsterId, input.Id);
			Assert.Equal(name, input.Name);
			Assert.Equal(hitPoints, input.HitPoints);
			Assert.Equal(experience, input.Experience);
			Assert.Equal(difficultyCategory, input.DifficultyCategory);
			Assert.Equal(elementsWeaknessMonster, input.ElementsWeaknessMonster);
		}
	}
}
