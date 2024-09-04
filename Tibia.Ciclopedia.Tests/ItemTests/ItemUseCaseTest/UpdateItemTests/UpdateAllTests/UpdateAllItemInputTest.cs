﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdateAllTest
{
	public class UpdateAllItemInputTest
	{
		[Fact]
		public void UpdateAllItemInput_Should_Have_Valid_Properties()
		{
			// Arrange
			var name = "ItemName";
			var type = ItemType.Boots;
			var vocations = Vocations.Sorcerer;
			var levelRequired = 10;
			var slots = new SlotsInfo();
			var price = 99.99;
			var image = "image_path";

			// Act
			var input = new UpdateAllItemInput
			{
				Name = name,
				Type = type,
				Vocations = vocations,
				LevelRequired = levelRequired,
				Slots = slots,
				Price = price,
				Image = image
			};

			// Assert
			Assert.Equal(name, input.Name);
			Assert.Equal(type, input.Type);
			Assert.Equal(vocations, input.Vocations);
			Assert.Equal(levelRequired, input.LevelRequired);
			Assert.Equal(slots, input.Slots);
			Assert.Equal(price, input.Price);
			Assert.Equal(image, input.Image);
		}
	}
}