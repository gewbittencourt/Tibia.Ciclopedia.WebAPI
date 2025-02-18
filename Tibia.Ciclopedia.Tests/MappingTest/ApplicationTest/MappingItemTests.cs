using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.Mapping;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Tests.MappingTest.ApplicationTest
{
	public class MappingItemTests
	{
		private readonly IMapper _mapper;

		public MappingItemTests()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingItem>());
			_mapper = config.CreateMapper();
		}

		[Fact]
		public void Mapping_CreateItemInput_To_Item_MapsCorrectly()
		{
			// Arrange
			var input = new CreateItemInput
			{
				Name = "Test Item",
				Type = Domain.Items.Enums.ItemType.Armor,
				Vocations = Domain.Items.Enums.Vocations.Knight,
				Slots = new SlotsInfoItem(true, 2),
				LevelRequired = 15,
				PurchasePrice = 1000,
				SellingPrice = 2000,
				Image = "image.jpg"
			};

			// Act
			var result = _mapper.Map<Item>(input);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(input.Name, result.Name);
			Assert.Equal(input.Type, result.Type);
			Assert.Equal(input.Vocations, result.Vocations);
			Assert.Equal(input.Slots.Quantity, result.Slots.Quantity);
			Assert.Equal(input.Slots.HaveSlots, result.Slots.HaveSlots);
			Assert.Equal(input.LevelRequired, result.LevelRequired);
			Assert.Equal(input.PurchasePrice, result.PurchasePrice);
			Assert.Equal(input.SellingPrice, result.SellingPrice);
			Assert.Equal(input.Image, result.Image);
			Assert.NotEqual(Guid.Empty, result.Id);
			Assert.NotNull(result.CreatedAt);
			Assert.Equal(input.Name.ToLowerInvariant().Replace(" ", ""), result.Slug);
		}
	}
}
