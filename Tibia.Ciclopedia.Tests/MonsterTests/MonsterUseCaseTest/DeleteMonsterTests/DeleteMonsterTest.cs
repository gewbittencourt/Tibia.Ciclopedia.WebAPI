using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster;
using Tibia.Ciclopedia.Domain.Monsters;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.DeleteMonsterTests
{
	public class DeleteMonsterTests
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly DeleteMonster _deleteMonsterUseCase;

		public DeleteMonsterTests()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_deleteMonsterUseCase = new DeleteMonster(_monsterRepositoryMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccess_WhenMonsterIsDeleted()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var input = new DeleteMonsterInput { id = monsterId };

			_monsterRepositoryMock.Setup(r => r.DeleteMonster(monsterId, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(true);

			// Act
			var result = await _deleteMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.True(result.Result);
			_monsterRepositoryMock.Verify(r => r.DeleteMonster(monsterId, It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnFailure_WhenMonsterDeletionFails()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var input = new DeleteMonsterInput { id = monsterId };

			_monsterRepositoryMock.Setup(r => r.DeleteMonster(monsterId, It.IsAny<CancellationToken>()))
								  .ReturnsAsync(false);

			// Act
			var result = await _deleteMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.False(result.IsValid);
			Assert.Contains("Não foi possível deleter o monstro.", result.Errors);
			_monsterRepositoryMock.Verify(r => r.DeleteMonster(monsterId, It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
