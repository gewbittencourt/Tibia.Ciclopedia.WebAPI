using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Domain.Monsters;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests.MonsterUseCaseTests.CreateMonsterTests
{
	public class CreateMonsterTest
	{
		private readonly Mock<IMonsterRepository> _monsterRepositoryMock;
		private readonly Mock<IMapper> _mapperMock;
		private readonly CreateMonster _createMonsterUseCase;

		public CreateMonsterTest()
		{
			_monsterRepositoryMock = new Mock<IMonsterRepository>();
			_mapperMock = new Mock<IMapper>();
			_createMonsterUseCase = new CreateMonster(_monsterRepositoryMock.Object, _mapperMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccess_WhenMonsterIsCreated()
		{
			// Arrange
			var input = new CreateMonsterInput();

			var monster = new Monster();
			monster.NewMonster();

			_mapperMock.Setup(m => m.Map<Monster>(input)).Returns(monster);
			_monsterRepositoryMock.Setup(m => m.CreateNewMonster(monster, It.IsAny<CancellationToken>()))
								  .Returns(Task.CompletedTask);

			// Act
			var result = await _createMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Equal(monster.Id, result.Result);
			_mapperMock.Verify(m => m.Map<Monster>(input), Times.Once);
			_monsterRepositoryMock.Verify(r => r.CreateNewMonster(monster, It.IsAny<CancellationToken>()), Times.Once);
		}

		[Fact]
		public async Task Handle_ShouldReturnFailure_WhenExceptionIsThrown()
		{
			// Arrange
			var input = new CreateMonsterInput();

			// Simulando um retorno nulo no mapeamento para evitar exceção direta
			_mapperMock.Setup(m => m.Map<Monster>(input)).Throws(new Exception("Não foi possível cadastrar o monstro"));

			// Act
			var result = await _createMonsterUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.False(result.IsValid);
			Assert.NotEmpty(result.Errors); // Verifica se Errors contém uma mensagem apropriada
			_mapperMock.Verify(m => m.Map<Monster>(input), Times.Once);
			_monsterRepositoryMock.Verify(r => r.CreateNewMonster(It.IsAny<Monster>(), It.IsAny<CancellationToken>()), Times.Never);
		}
	}
}
