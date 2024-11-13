using System;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.CreateMonsterTests
{
	public class CreateMonsterInputTests
	{
		[Fact]
		public void CreateMonsterInput_ShouldSetPropertiesCorrectly()
		{
			// Arrange
			var name = "Ferumbras";
			var hitPoints = 10000;
			var experience = 5000;
			var difficultyCategory = MonsterDifficulty.Hard;
			var elementsWeaknessMonster = new ElementsWeaknessMonster(100,100,100,100,100,100,100);

			// Act
			var input = new CreateMonsterInput
			{
				Name = name,
				HitPoints = hitPoints,
				Experience = experience,
				DifficultyCategory = difficultyCategory,
				ElementsWeaknessMonster = elementsWeaknessMonster
			};


			// Assert
			Assert.Equal(name, input.Name);
			Assert.Equal(hitPoints, input.HitPoints);
			Assert.Equal(experience, input.Experience);
			Assert.Equal(difficultyCategory, input.DifficultyCategory);
			Assert.Equal(elementsWeaknessMonster, input.ElementsWeaknessMonster);
		}
	}
}
