using System;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Xunit;

namespace Tibia.Ciclopedia.Tests.Domain.Monsters
{
	public class MonsterEntitieTests
	{
		[Fact]
		public void NewMonster_ShouldGenerateNewGuid()
		{
			// Arrange
			var monster = new Monster();

			// Act
			monster.NewMonster();

			// Assert
			Assert.NotEqual(Guid.Empty, monster.Id);
		}

		[Fact]
		public void UpdateMonster_ShouldUpdateName_WhenNameIsNotNullOrEmpty()
		{
			// Arrange
			var monster = new Monster();
			string newName = "Orc";

			// Act
			monster.UpdateMonster(newName, null, null, null, null);

			// Assert
			Assert.Equal(newName, monster.Name);
		}

		[Fact]
		public void UpdateMonster_ShouldNotUpdateName_WhenNameIsNullOrEmpty()
		{
			// Arrange
			var monster = new Monster();
			monster.UpdateMonster("Orc", null, null, null, null);

			// Act
			monster.UpdateMonster(string.Empty, null, null, null, null);

			// Assert
			Assert.Equal("Orc", monster.Name);
		}

		[Fact]
		public void UpdateMonster_ShouldUpdateHitPoints_WhenHitPointsIsNotNull()
		{
			// Arrange
			var monster = new Monster();
			int newHitPoints = 200;

			// Act
			monster.UpdateMonster(null, newHitPoints, null, null, null);

			// Assert
			Assert.Equal(newHitPoints, monster.HitPoints);
		}

		[Fact]
		public void UpdateMonster_ShouldUpdateExperience_WhenExperienceIsNotNull()
		{
			// Arrange
			var monster = new Monster();
			int newExperience = 500;

			// Act
			monster.UpdateMonster(null, null, newExperience, null, null);

			// Assert
			Assert.Equal(newExperience, monster.Experience);
		}

		[Fact]
		public void UpdateMonster_ShouldUpdateDifficultyCategory_WhenDifficultyCategoryIsNotNull()
		{
			// Arrange
			var monster = new Monster();
			var newDifficulty = MonsterDifficulty.Hard;

			// Act
			monster.UpdateMonster(null, null, null, newDifficulty, null);

			// Assert
			Assert.Equal(newDifficulty, monster.DifficultyCategory);
		}

		[Fact]
		public void UpdateMonster_ShouldUpdateElementsWeaknessMonster_WhenElementsWeaknessMonsterIsNotNull()
		{
			// Arrange
			var monster = new Monster();
			var newWeakness = new ElementsWeaknessMonster(100,100,100,100,100,100,100);

			// Act
			monster.UpdateMonster(null, null, null, null, newWeakness);

			// Assert
			Assert.Equal(newWeakness, monster.ElementsWeaknessMonster);
		}
	}
}
