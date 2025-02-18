using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTest.GetMonsterTests.GetByElementWeaknessAndDifficultyTests
{
	public class GetMonsterByWeaknessAndDifficultyTests
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly GetMonsterByWeaknessAndDifficulty _getMonsterByWeaknessAndDifficultyUseCase;

		public GetMonsterByWeaknessAndDifficultyTests()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_getMonsterByWeaknessAndDifficultyUseCase = new GetMonsterByWeaknessAndDifficulty(_monsterRepositoryMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnMonsters_WhenMonstersMatchCriteria()
		{
			// Arrange
			var element = "fire";
			var difficulty = MonsterDifficulty.Hard;
			var monsters = new List<Monster>
			{
				new Monster(),
				new Monster()
			};

			var input = new GetMonsterByWeaknessAndDifficultyInput
			{
				Element = element,
				DifficultyCategory = difficulty
			};

			_monsterRepositoryMock.Setup(r => r.GetMonsterByElementAndDifficulty("Fire", difficulty, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(monsters);

			// Act
			var result = await _getMonsterByWeaknessAndDifficultyUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Equal(monsters, result.Result);
			_monsterRepositoryMock.Verify(r => r.GetMonsterByElementAndDifficulty("Fire", difficulty, It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnEmptyList_WhenNoMonstersMatchCriteria()
		{
			// Arrange
			var element = "ice";
			var difficulty = MonsterDifficulty.Medium;
			var input = new GetMonsterByWeaknessAndDifficultyInput
			{
				Element = element,
				DifficultyCategory = difficulty
			};

			_monsterRepositoryMock.Setup(r => r.GetMonsterByElementAndDifficulty("Ice", difficulty, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(new List<Monster>());

			// Act
			var result = await _getMonsterByWeaknessAndDifficultyUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Empty(result.Result);
			_monsterRepositoryMock.Verify(r => r.GetMonsterByElementAndDifficulty("Ice", difficulty, It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
