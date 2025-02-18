using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Tibia.Ciclopedia.Domain.Monsters;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.GetMonsterTests.GetAllMonsterTests
{
	public class GetAllMonstersTests
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly GetAllMonsters _getAllMonstersUseCase;

		public GetAllMonstersTests()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_getAllMonstersUseCase = new GetAllMonsters(_monsterRepositoryMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnMonsterList_WhenMonstersAreAvailable()
		{
			// Arrange
			var monsters = new List<Monster>
			{
				new Monster (),
				new Monster()
			};

			_monsterRepositoryMock.Setup(r => r.GetAllMonsters(It.IsAny<CancellationToken>()))
								  .ReturnsAsync(monsters);

			var input = new GetAllMonsterInput();

			// Act
			var result = await _getAllMonstersUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Equal(monsters, result.Result);
			_monsterRepositoryMock.Verify(r => r.GetAllMonsters(It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnEmptyList_WhenNoMonstersAreAvailable()
		{
			// Arrange
			var monsters = new List<Monster>();

			_monsterRepositoryMock.Setup(r => r.GetAllMonsters(It.IsAny<CancellationToken>()))
								  .ReturnsAsync(monsters);

			var input = new GetAllMonsterInput();

			// Act
			var result = await _getAllMonstersUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Empty(result.Result);
			_monsterRepositoryMock.Verify(r => r.GetAllMonsters(It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
