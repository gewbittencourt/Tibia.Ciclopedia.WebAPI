using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName;
using Tibia.Ciclopedia.Domain.Monsters;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.GetMonsterTests.GetByNameMonsterTests
{
	public class GetMonsterByNameTests
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly GetMonsterByName _getMonsterByNameUseCase;

		public GetMonsterByNameTests()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_getMonsterByNameUseCase = new GetMonsterByName(_monsterRepositoryMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnMonster_WhenMonsterExists()
		{
			// Arrange
			var monsterName = "Dragon";
			var monster = new Monster();
			var input = new GetMonsterByNameInput { Name = monsterName };

			_monsterRepositoryMock.Setup(r => r.GetMonsterByName(monsterName, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(monster);

			// Act
			var result = await _getMonsterByNameUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Equal(monster, result.Result);
			_monsterRepositoryMock.Verify(r => r.GetMonsterByName(monsterName, It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnFailure_WhenMonsterDoesNotExist()
		{
			// Arrange
			var monsterName = "NonExistentMonster";
			var input = new GetMonsterByNameInput { Name = monsterName };

			_monsterRepositoryMock.Setup(r => r.GetMonsterByName(monsterName, It.IsAny<CancellationToken>()))
								  .ReturnsAsync((Monster)null);

			// Act
			var result = await _getMonsterByNameUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.False(result.IsValid);
			Assert.Contains("Monstro não encontrado", result.Errors);
			_monsterRepositoryMock.Verify(r => r.GetMonsterByName(monsterName, It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
