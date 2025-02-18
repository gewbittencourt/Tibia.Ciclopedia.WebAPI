using System;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.DeleteMonsterTests
{
	public class DeleteMonsterInputTests
	{
		[Fact]
		public void DeleteMonsterInput_ShouldSetIdProperty()
		{
			// Arrange
			var monsterId = Guid.NewGuid();

			// Act
			var input = new DeleteMonsterInput { id = monsterId };

			// Assert
			Assert.Equal(monsterId, input.id);
		}
	}
}
