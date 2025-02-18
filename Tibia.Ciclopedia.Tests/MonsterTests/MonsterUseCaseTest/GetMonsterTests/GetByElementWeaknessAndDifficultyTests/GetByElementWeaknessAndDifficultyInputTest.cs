using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTest.GetMonsterTests.GetByElementWeaknessAndDifficultyTests
{
	public class GetMonsterByWeaknessAndDifficultyInputTests
	{
		[Fact]
		public void GetMonsterByWeaknessAndDifficultyInput_ShouldSetPropertiesCorrectly()
		{
			// Arrange
			var element = "fire";
			var difficultyCategory = MonsterDifficulty.Hard;

			// Act
			var input = new GetMonsterByWeaknessAndDifficultyInput
			{
				Element = element,
				DifficultyCategory = difficultyCategory
			};

			// Assert
			Assert.Equal(element, input.Element);
			Assert.Equal(difficultyCategory, input.DifficultyCategory);
		}
	}
}

