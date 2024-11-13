using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MongoDB.Driver;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Xunit;

namespace Tibia.Ciclopedia.Tests.MonsterTests
{
	public class MonsterRepositoryTests
	{
		private readonly Mock<IMongoCollection<MonsterCollection>> _monsterCollectionMock;
		private readonly Mock<IMapper> _mapperMock;
		private readonly MonsterRepository _repository;

		public MonsterRepositoryTests()
		{
			_monsterCollectionMock = new Mock<IMongoCollection<MonsterCollection>>();
			_mapperMock = new Mock<IMapper>();
			_repository = new MonsterRepository(_monsterCollectionMock.Object, _mapperMock.Object);
		}





		[Fact]
		public async Task CreateNewMonster_ShouldInsertMonsterIntoCollection()
		{
			// Arrange
			var monster = new Monster();
			var monsterCollection = new MonsterCollection();
			_mapperMock.Setup(m => m.Map<MonsterCollection>(monster)).Returns(monsterCollection);

			// Act
			await _repository.CreateNewMonster(monster, CancellationToken.None);

			// Assert
			_monsterCollectionMock.Verify(m => m.InsertOneAsync(monsterCollection, It.IsAny<InsertOneOptions>(), CancellationToken.None), Times.Once);
		}


		[Fact]
		public async Task GetAllMonsters_ShouldReturnAllMonsters()
		{
			// Arrange
			var monsterCollectionList = new List<MonsterCollection> { new MonsterCollection() };

			// Mock IAsyncCursor to simulate MongoDB query results
			var asyncCursorMock = new Mock<IAsyncCursor<MonsterCollection>>();
			asyncCursorMock.Setup(_ => _.Current).Returns(monsterCollectionList);
			asyncCursorMock
				.SetupSequence(_ => _.MoveNext(It.IsAny<CancellationToken>()))
				.Returns(true)
				.Returns(false);
			asyncCursorMock
				.SetupSequence(_ => _.MoveNextAsync(It.IsAny<CancellationToken>()))
				.ReturnsAsync(true)
				.ReturnsAsync(false);

			// Use FindAsync instead of Find
			_monsterCollectionMock.Setup(m => m.FindAsync(It.IsAny<FilterDefinition<MonsterCollection>>(),
														  It.IsAny<FindOptions<MonsterCollection>>(),
														  It.IsAny<CancellationToken>()))
								  .ReturnsAsync(asyncCursorMock.Object);

			_mapperMock.Setup(m => m.Map<IEnumerable<Monster>>(monsterCollectionList)).Returns(new List<Monster> { new Monster() });

			// Act
			var result = await _repository.GetAllMonsters(CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			_mapperMock.Verify(m => m.Map<IEnumerable<Monster>>(monsterCollectionList), Times.Once);
		}


		[Fact]
		public async Task GetMonsterByName_ReturnsOneMonster_WhenSuccessful()
		{
			// Arrange
			var monsterCollection = new MonsterCollection { Name = "Dragon" };
			var name = "Dragon";
			var monster = new Monster(name);

			// SIMULAÇÃO DO FIND
			var mockCursor = new Mock<IAsyncCursor<MonsterCollection>>();
			mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
			mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true).ReturnsAsync(false);
			mockCursor.Setup(x => x.Current).Returns(new List<MonsterCollection> { monsterCollection });

			_monsterCollectionMock.Setup(x => x.FindAsync(
				It.IsAny<FilterDefinition<MonsterCollection>>(),
				It.IsAny<FindOptions<MonsterCollection, MonsterCollection>>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

			_mapperMock.Setup(mapper => mapper.Map<Monster>(monsterCollection))
					   .Returns(monster);

			// Act
			var result = await _repository.GetMonsterByName(name, It.IsAny<CancellationToken>());

			// Assert
			Assert.NotNull(result);
			Assert.IsType<Monster>(result);
			Assert.Equal(name, result.Name);
		}




		[Fact]
		public async Task GetMonsterByElementAndDifficulty_ShouldReturnMonsters_WhenMonstersExist()
		{
			// Arrange
			var element = "Fire";
			var difficulty = MonsterDifficulty.Hard;
			var monsterCollectionList = new List<MonsterCollection> { new MonsterCollection() };
			var monsterList = new List<Monster> { new Monster() };

			// SIMULAÇÃO DO FIND
			var mockCursor = new Mock<IAsyncCursor<MonsterCollection>>();
			mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
			mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true).ReturnsAsync(false);
			mockCursor.Setup(x => x.Current).Returns(monsterCollectionList);

			_monsterCollectionMock.Setup(x => x.FindAsync(
				It.IsAny<FilterDefinition<MonsterCollection>>(),
				It.IsAny<FindOptions<MonsterCollection, MonsterCollection>>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

			_mapperMock.Setup(mapper => mapper.Map<List<Monster>>(monsterCollectionList))
					   .Returns(monsterList);

			// Act
			var result = await _repository.GetMonsterByElementAndDifficulty(element, difficulty, CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			_mapperMock.Verify(m => m.Map<IEnumerable<Monster>>(monsterCollectionList), Times.Once);
		}





		[Fact]
		public async Task GetMonsterById_ReturnsOneMonster_WhenSuccessful()
		{
			// Arrange
			var id = new Guid();
			var monsterCollection = new MonsterCollection { MonsterId = id };
			var monster = new Monster();

			// SIMULAÇÃO DO FIND
			var mockCursor = new Mock<IAsyncCursor<MonsterCollection>>();
			mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
			mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true).ReturnsAsync(false);
			mockCursor.Setup(x => x.Current).Returns(new List<MonsterCollection> { monsterCollection });

			_monsterCollectionMock.Setup(x => x.FindAsync(
				It.IsAny<FilterDefinition<MonsterCollection>>(),
				It.IsAny<FindOptions<MonsterCollection, MonsterCollection>>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

			_mapperMock.Setup(mapper => mapper.Map<Monster>(monsterCollection))
					   .Returns(monster);

			// Act
			var result = await _repository.GetMonsterById(id, It.IsAny<CancellationToken>());

			// Assert
			Assert.NotNull(result);
			Assert.IsType<Monster>(result);
			Assert.Equal(id, result.Id);
		}




		[Fact]
		public async Task UpdateMonster_ShouldReturnTrue_WhenMonsterIsUpdated()
		{
			// Arrange
			var monster = new Monster();
			var monsterCollection = new MonsterCollection();
			_mapperMock.Setup(m => m.Map<MonsterCollection>(monster)).Returns(monsterCollection);
			_monsterCollectionMock.Setup(m => m.UpdateOneAsync(It.IsAny<FilterDefinition<MonsterCollection>>(), It.IsAny<UpdateDefinition<MonsterCollection>>(), null, CancellationToken.None))
								  .ReturnsAsync(new UpdateResult.Acknowledged(1, 1, null));

			// Act
			var result = await _repository.UpdateMonster(monster, CancellationToken.None);

			// Assert
			Assert.True(result);
		}




		[Fact]
		public async Task UpdateMonster_ShouldReturnFalse_WhenMonsterIsNotUpdated()
		{
			// Arrange
			var monster = new Monster();
			var monsterCollection = new MonsterCollection();
			_mapperMock.Setup(m => m.Map<MonsterCollection>(monster)).Returns(monsterCollection);
			_monsterCollectionMock.Setup(m => m.UpdateOneAsync(It.IsAny<FilterDefinition<MonsterCollection>>(), It.IsAny<UpdateDefinition<MonsterCollection>>(), null, CancellationToken.None))
								  .ReturnsAsync(new UpdateResult.Acknowledged(0, 0, null));

			// Act
			var result = await _repository.UpdateMonster(monster, CancellationToken.None);

			// Assert
			Assert.False(result);
		}




		[Fact]
		public async Task DeleteMonster_ShouldReturnTrue_WhenMonsterIsDeleted()
		{
			// Arrange
			var id = Guid.NewGuid();
			_monsterCollectionMock.Setup(m => m.DeleteOneAsync(It.IsAny<FilterDefinition<MonsterCollection>>(), CancellationToken.None))
								  .ReturnsAsync(new DeleteResult.Acknowledged(1));

			// Act
			var result = await _repository.DeleteMonster(id, CancellationToken.None);

			// Assert
			Assert.True(result);
		}




		[Fact]
		public async Task DeleteMonster_ShouldReturnFalse_WhenMonsterIsNotDeleted()
		{
			// Arrange
			var id = Guid.NewGuid();
			_monsterCollectionMock.Setup(m => m.DeleteOneAsync(It.IsAny<FilterDefinition<MonsterCollection>>(), CancellationToken.None))
								  .ReturnsAsync(new DeleteResult.Acknowledged(0));

			// Act
			var result = await _repository.DeleteMonster(id, CancellationToken.None);

			// Assert
			Assert.False(result);
		}
	}
}
