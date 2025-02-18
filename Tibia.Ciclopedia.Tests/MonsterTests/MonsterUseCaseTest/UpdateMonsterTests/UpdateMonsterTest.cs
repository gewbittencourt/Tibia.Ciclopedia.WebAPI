using Moq;
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
	public class UpdateMonsterTests
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly UpdateMonster _updateMonsterUseCase;

		public UpdateMonsterTests()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_updateMonsterUseCase = new UpdateMonster(_monsterRepositoryMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccess_WhenMonsterIsUpdated()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var input = new UpdateMonsterInput
			{
				Id = monsterId,
				Name = "Dragon",
				HitPoints = 5000,
				Experience = 1000,
				DifficultyCategory = MonsterDifficulty.Medium,
				ElementsWeaknessMonster = new ElementsWeaknessMonster(100, 100, 100, 100, 100, 100, 100)
			};

			var monster = new Monster();
			_monsterRepositoryMock.Setup(r => r.GetMonsterById(monsterId, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(monster);

			_monsterRepositoryMock.Setup(r => r.UpdateMonster(monster, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(true);

			// Act
			var result = await _updateMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.True(result.Result);
			_monsterRepositoryMock.Verify(r => r.GetMonsterById(monsterId, It.IsAny<CancellationToken>()), Times.Once);
			_monsterRepositoryMock.Verify(r => r.UpdateMonster(monster, It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnFailure_WhenMonsterNotFound()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var input = new UpdateMonsterInput
			{
				Id = monsterId,
				Name = "Dragon",
				HitPoints = 5000,
				Experience = 1000,
				DifficultyCategory = MonsterDifficulty.Medium,
				ElementsWeaknessMonster = new ElementsWeaknessMonster(100, 100, 100, 100, 100, 100, 100)
			};

			_monsterRepositoryMock.Setup(r => r.GetMonsterById(monsterId, It.IsAny<CancellationToken>()))
								  .ReturnsAsync((Monster)null);

			// Act
			var result = await _updateMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.False(result.IsValid);
			Assert.Contains("Não foi possível encontrar o monstro especificado.", result.Errors);
			_monsterRepositoryMock.Verify(r => r.GetMonsterById(monsterId, It.IsAny<CancellationToken>()), Times.Once);
			_monsterRepositoryMock.Verify(r => r.UpdateMonster(It.IsAny<Monster>(), It.IsAny<CancellationToken>()), Times.Never);
		}
	}
}
