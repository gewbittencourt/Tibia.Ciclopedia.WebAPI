using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Tests.MonsterTests.CollectionTest
{
	public class MonsterCollectionTests
	{
		[Fact]
		public void MonsterCollection_Should_SetAndRetrieveProperties()
		{
			// Arrange
			var monsterId = Guid.NewGuid();
			var name = "Test Monster";
			var hitPoints = 500;
			var experience = 1000;
			var difficultyCategory = MonsterDifficultyCollectionMember.Hard;
			var elementsWeakness = new ElementsWeaknessMonsterCollectionMember
			{
				Fire = 100,
				Ice = 100,
				Earth = 100,
				Death = 100,
				Energy = 100,
				Holy = 100,
				Physical = 100
			};

			var monsterCollection = new MonsterCollection
			{
				Id = ObjectId.GenerateNewId(),
				MonsterId = monsterId,
				Name = name,
				HitPoints = hitPoints,
				Experience = experience,
				DifficultyCategory = difficultyCategory,
				ElementsWeaknessMonster = elementsWeakness
			};

			// Act & Assert
			Assert.NotNull(monsterCollection.Id);
			Assert.Equal(monsterId, monsterCollection.MonsterId);
			Assert.Equal(name, monsterCollection.Name);
			Assert.Equal(hitPoints, monsterCollection.HitPoints);
			Assert.Equal(experience, monsterCollection.Experience);
			Assert.Equal(difficultyCategory, monsterCollection.DifficultyCategory);
			Assert.Equal(elementsWeakness, monsterCollection.ElementsWeaknessMonster);
		}
	}
}