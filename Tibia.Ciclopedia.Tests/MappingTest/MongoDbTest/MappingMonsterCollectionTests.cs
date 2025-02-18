using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;

namespace Tibia.Ciclopedia.Tests.MappingTest.MongoDbTest
{
	public class MappingMonsterCollectionTests
	{
		private readonly IMapper _mapper;

		public MappingMonsterCollectionTests()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingMonsterCollection>());
			_mapper = config.CreateMapper();
		}

		[Fact]
		public void Mapping_Configuration_IsValid()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingMonsterCollection>());
			config.AssertConfigurationIsValid();
		}

		[Fact]
		public void Mapping_Monster_To_MonsterCollection_MapsCorrectly()
		{
			// Arrange
			var elementsWeakness = new ElementsWeaknessMonster(100, 100, 100, 100, 100, 100, 100);

			var monster = new Monster();
			monster.NewMonster();
			monster.UpdateMonster(
			name: "Dragon",
			hitPoints: 5000,
			experience: 1000,
			difficultyCategory: MonsterDifficulty.Hard,
			elementsWeaknessMonster: elementsWeakness);



			// Act
			var result = _mapper.Map<MonsterCollection>(monster);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(monster.Id, result.MonsterId);
			Assert.Equal(monster.Name, result.Name);
			Assert.Equal(monster.HitPoints, result.HitPoints);
			Assert.Equal(monster.Experience, result.Experience);
			Assert.Equal(monster.DifficultyCategory.ToString(), result.DifficultyCategory.ToString());
			Assert.Equal(monster.ElementsWeaknessMonster.Death, result.ElementsWeaknessMonster.Death);
		}

		[Fact]
		public void Mapping_MonsterCollection_To_Monster_MapsCorrectly()
		{
			// Arrange
			var elementsWeakness = new ElementsWeaknessMonsterCollectionMember
			{
				Death = 100,
				Earth = 100,
				Energy = 100,
				Fire = 100,
				Holy = 100,
				Ice = 100,
				Physical = 100
			};

			var monsterCollection = new MonsterCollection
			{
				MonsterId = Guid.NewGuid(),
				Name = "Behemoth",
				HitPoints = 1200,
				Experience = 800,
				DifficultyCategory = MonsterDifficultyCollectionMember.Challenging,
				ElementsWeaknessMonster = elementsWeakness
			};

			// Act
			var result = _mapper.Map<Monster>(monsterCollection);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(monsterCollection.MonsterId, result.Id);
			Assert.Equal(monsterCollection.Name, result.Name);
			Assert.Equal(monsterCollection.HitPoints, result.HitPoints);
			Assert.Equal(monsterCollection.Experience, result.Experience);
			Assert.Equal(monsterCollection.DifficultyCategory.ToString(), result.DifficultyCategory.ToString());
			Assert.Equal(monsterCollection.ElementsWeaknessMonster.Death, result.ElementsWeaknessMonster.Death);
		}

		[Fact]
		public void Mapping_ElementsWeaknessMonsterCollectionMember_To_ElementsWeaknessMonster_MapsCorrectly()
		{
			// Arrange
			var source = new ElementsWeaknessMonsterCollectionMember
			{
				Death = 100,
				Earth = 100,
				Energy = 100,
				Fire = 100,
				Holy = 100,
				Ice = 100,
				Physical = 100
			};

			// Act
			var result = _mapper.Map<ElementsWeaknessMonster>(source);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(source.Death, result.Death);
			Assert.Equal(source.Holy, result.Holy);
		}

		[Fact]
		public void Mapping_MonsterDifficultyCollectionMember_To_MonsterDifficulty_MapsCorrectly()
		{
			// Arrange
			var source = MonsterDifficultyCollectionMember.Hard;

			// Act
			var result = _mapper.Map<MonsterDifficulty>(source);

			// Assert
			Assert.Equal(source.ToString(), result.ToString());
		}
	}
}
