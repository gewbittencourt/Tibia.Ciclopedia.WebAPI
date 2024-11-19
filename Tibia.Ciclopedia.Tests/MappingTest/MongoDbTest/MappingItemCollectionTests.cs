using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.ItemMember;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping;
using Tibia.Ciclopedia.Domain.Items.Enums;

namespace Tibia.Ciclopedia.Tests.MappingTest.MongoDbTest
{
	public class MappingItemCollectionTests
	{
		private readonly IMapper _mapper;

		public MappingItemCollectionTests()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingItemCollection>());
			_mapper = config.CreateMapper();
		}

		[Fact]
		public void Mapping_Configuration_IsValid()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingItemCollection>());
			config.AssertConfigurationIsValid();
		}

		[Fact]
		public void Mapping_Item_To_ItemCollection_MapsCorrectly()
		{
			// Arrange
			var period = new PeriodControl();
			var slots = new SlotsInfoItem(true,2);

			var item = new Item("Test Item", ItemType.Wand, Vocations.Knight, slots, 100, 100, "image.jpg", 10);
			item.NewItem();
			item.UpdatePriceItem(100);
			item.CheckPeriod();


			// Act
			var result = _mapper.Map<ItemCollection>(item);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(item.Id, result.ItemID);
			Assert.Equal(item.Period.TimeCheckedExpire, result.Period.TimeCheckedExpire);
			Assert.Equal(item.Period.TimeChecked, result.Period.TimeChecked);
			Assert.Equal(item.Slots.Quantity, result.Slots.Quantity);
			Assert.Equal(item.Slots.HaveSlots, result.Slots.HaveSlots);
		}

		[Fact]
		public void Mapping_ItemCollection_To_Item_MapsCorrectly()
		{
			// Arrange
			var period = new PeriodControlCollectionMember { TimeChecked = DateTime.UtcNow, TimeCheckedExpire = DateTime.UtcNow.AddDays(7) };
			var slots = new SlotsInfoItemCollectionMember { Quantity = 3, HaveSlots = false };
			var itemCollection = new ItemCollection
			{
				ItemID = Guid.NewGuid(),
				Period = period,
				Slots = slots
			};

			// Act
			var result = _mapper.Map<Item>(itemCollection);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(itemCollection.ItemID, result.Id);
			Assert.Equal(itemCollection.Period.TimeChecked, result.Period.TimeChecked);
			Assert.Equal(itemCollection.Period.TimeCheckedExpire, result.Period.TimeCheckedExpire);
			Assert.Equal(itemCollection.Slots.Quantity, result.Slots.Quantity);
			Assert.Equal(itemCollection.Slots.HaveSlots, result.Slots.HaveSlots);
		}

		[Fact]
		public void Mapping_PeriodControl_To_PeriodControlCollectionMember_MapsCorrectly()
		{
			// Arrange
			var source = new PeriodControl();

			// Act
			var result = _mapper.Map<PeriodControlCollectionMember>(source);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(source.TimeChecked, result.TimeChecked);
			Assert.Equal(source.TimeCheckedExpire, result.TimeCheckedExpire);
		}

		[Fact]
		public void Mapping_SlotsInfoItem_To_SlotsInfoItemCollectionMember_MapsCorrectly()
		{
			// Arrange
			var source = new SlotsInfoItem(true, 5);


			// Act
			var result = _mapper.Map<SlotsInfoItemCollectionMember>(source);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(source.Quantity, result.Quantity);
			Assert.Equal(source.HaveSlots, result.HaveSlots);
		}
	}
}
