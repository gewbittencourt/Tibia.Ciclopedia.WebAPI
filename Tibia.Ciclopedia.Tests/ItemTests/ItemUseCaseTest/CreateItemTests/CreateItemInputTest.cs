using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.CreateItemTests
{
	public class CreateItemInputTest
	{
		[Fact]
		public void CreateItemInput_CanBeConstructedAndInitialized()
		{
			// Arrange & Act
			var createItemInput = new CreateItemInput
			{
				Name = "Golden Boots",
				Type = ItemType.Boots,
				Vocations = Vocations.Knight | Vocations.Paladin,
				LevelRequired = 20,
				Slots = new SlotsInfoItem (true,1),
				Image = "linktest"
				
			};

			// Assert
			Assert.Equal("Golden Boots", createItemInput.Name);
			Assert.Equal(ItemType.Boots, createItemInput.Type);
			Assert.Equal(Vocations.Knight | Vocations.Paladin, createItemInput.Vocations);
			Assert.Equal(20, createItemInput.LevelRequired);
			Assert.True(createItemInput.Slots.HaveSlots);
			Assert.Equal(1, createItemInput.Slots.Quantity);
		}
	}
}
