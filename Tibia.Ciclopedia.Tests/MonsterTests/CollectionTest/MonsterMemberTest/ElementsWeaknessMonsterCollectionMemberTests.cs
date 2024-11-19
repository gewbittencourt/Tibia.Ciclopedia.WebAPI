using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;

namespace Tibia.Ciclopedia.Tests.MonsterTests.CollectionTest.MonsterMemberTest
{
	public class ElementsWeaknessMonsterCollectionMemberTests
	{
		[Fact]
		public void ElementsWeaknessMonsterCollectionMember_Should_SetAndRetrieveProperties()
		{
			// Arrange
			var physical = 10;
			var earth = 20;
			var fire = 30;
			var death = 40;
			var ice = 50;
			var energy = 60;
			var holy = 70;

			var elementsWeakness = new ElementsWeaknessMonsterCollectionMember
			{
				Physical = physical,
				Earth = earth,
				Fire = fire,
				Death = death,
				Ice = ice,
				Energy = energy,
				Holy = holy
			};

			// Act & Assert
			Assert.Equal(physical, elementsWeakness.Physical);
			Assert.Equal(earth, elementsWeakness.Earth);
			Assert.Equal(fire, elementsWeakness.Fire);
			Assert.Equal(death, elementsWeakness.Death);
			Assert.Equal(ice, elementsWeakness.Ice);
			Assert.Equal(energy, elementsWeakness.Energy);
			Assert.Equal(holy, elementsWeakness.Holy);
		}
	}
}
