using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.GetMonsterTests.GetByNameMonsterTests
{
	public class GetMonsterByNameInputTests
	{
		[Fact]
		public void GetMonsterByNameInput_ShouldSetNameProperty()
		{
			// Arrange
			var monsterName = "Dragon";

			// Act
			var input = new GetMonsterByNameInput { Name = monsterName };

			// Assert
			Assert.Equal(monsterName, input.Name);
		}

		[Fact]
		public void GetMonsterByNameInput_ShouldHaveNullNameByDefault()
		{
			// Act
			var input = new GetMonsterByNameInput();

			// Assert
			Assert.Null(input.Name);
		}
	}
}
