using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;


namespace Tibia.Ciclopedia.Tests.ItemTests
{
	public class ItemEntitieTest
	{
		[Fact]
		public void NewItem_ShouldSetIdAndDate()
		{
			// Arrange
			var item = new Item(name: "test", type: ItemType.Boots, vocations: Vocations.Druid, new SlotsInfoItem( true, 1 ), purchaseprice: 100,sellingprice: 100, image: "linktest", levelRequired: 100);

			// Act
			item.NewItem();

			// Assert
			Assert.NotEqual(Guid.Empty, item.Id);
			Assert.True((DateTime.Now - item.CreatedAt).TotalSeconds < 1);
			Assert.Equal("test", item.Name);
			Assert.Equal("Boots", item.Type.ToString());
			Assert.Equal("Druid", item.Vocations.ToString());
			Assert.Equal(true, item.Slots.HaveSlots);
			Assert.Equal(1, item.Slots.Quantity);
			Assert.Equal(100, item.PurchasePrice);
			Assert.Equal(100, item.SellingPrice);
			Assert.Equal("linktest", item.Image);
		}

		[Fact]
		public void NewItem_ShouldGenerateUniqueId()
		{
			// Arrange
			var item1 = new Item("Item1");
			var item2 = new Item("Item2");

			// Act
			item1.NewItem();
			item2.NewItem();

			// Assert
			Assert.NotEqual(item1.Id, item2.Id);
			Assert.NotEqual(Guid.Empty, item1.Id);
			Assert.NotEqual(Guid.Empty, item2.Id);
		}
	}
}