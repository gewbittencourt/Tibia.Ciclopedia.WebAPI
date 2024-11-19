using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.ItemMember;

namespace Tibia.Ciclopedia.Tests.ItemTests.CollectionTest.ItemMemberTest
{
	public class SlotsInfoItemCollectionMemberTests
	{
		[Fact]
		public void SlotsInfoItemCollectionMember_Should_SetAndRetrieveProperties()
		{
			// Arrange
			var haveSlots = true;
			var quantity = 5;

			var slotsInfo = new SlotsInfoItemCollectionMember
			{
				HaveSlots = haveSlots,
				Quantity = quantity
			};

			// Act & Assert
			Assert.Equal(haveSlots, slotsInfo.HaveSlots);
			Assert.Equal(quantity, slotsInfo.Quantity);
		}
	}
}
