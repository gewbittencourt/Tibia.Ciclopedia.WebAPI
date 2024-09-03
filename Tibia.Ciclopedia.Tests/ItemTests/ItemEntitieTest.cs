using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;

namespace Tibia.Ciclopedia.Tests.ItemTests
{
	public class ItemEntitieTest
	{
		[Fact]
		public void NewItem_ShouldSetIdAndDate()
		{
			// Arrange
			var item = new Item(name: "test", type: ItemType.Boots.ToString(), vocations: Vocations.Druid.ToString(), new SlotsInfo { HaveSlots = true, Quantity = 1 }, price: 100, image: "linktest", levelRequired: 100);

			// Act
			item.NewItem();

			// Assert
			Assert.NotEqual(Guid.Empty, item.Id);
			Assert.True((DateTime.Now - item.Date).TotalSeconds < 1);
			Assert.Equal("test", item.Name);
			Assert.Equal("Boots", item.Type);
			Assert.Equal("Druid", item.Vocations);
			Assert.Equal(true, item.Slots.HaveSlots);
			Assert.Equal(1, item.Slots.Quantity);
			Assert.Equal(100, item.Price);
			Assert.Equal("linktest", item.Image);
		}

		[Fact]
		public void NewItem_ShouldGenerateUniqueId()
		{
			// Arrange
			var item1 = new Item();
			var item2 = new Item();

			// Act
			item1.NewItem();
			item2.NewItem();

			// Assert
			Assert.NotEqual(item1.Id, item2.Id);
		}
	}
}