using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.GetMonsterTests.GetAllMonsterTests
{
	public class GetAllMonsterInputTests
	{
		[Fact]
		public void GetAllMonsterInput_ShouldCreateInstance()
		{
			// Act
			var input = new GetAllMonsterInput();

			// Assert
			Assert.NotNull(input);
		}
	}
}
