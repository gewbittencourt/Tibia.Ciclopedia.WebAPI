using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAll;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdateAllTest
{
	public class UpdateAllItemCommandTest
	{
		[Fact]
		public void UpdateAllItemCommand_Should_Have_Valid_Properties()
		{
			// Arrange
			var id = Guid.NewGuid();
			var input = new UpdateAllItemInput
			{
				Name = "ItemName",
				Type = ItemType.Bow,
				Vocations = Vocations.Paladin,
				LevelRequired = 10,
				Slots = new SlotsInfo(),
				Price = 99.99,
				Image = "image_path"
			};

			// Act
			var command = new UpdateAllItemCommand(id, input);

			// Assert
			Assert.Equal(id, command.Id);
			Assert.Equal(input, command.Input);
		}
	}
}