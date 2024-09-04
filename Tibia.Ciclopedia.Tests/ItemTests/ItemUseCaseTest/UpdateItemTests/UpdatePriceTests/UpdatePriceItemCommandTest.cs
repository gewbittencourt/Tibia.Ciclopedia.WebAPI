using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdatePrice;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTests.UpdatePriceTests
{
	public class UpdatePriceItemCommandTest
	{
		[Fact]
		public void UpdateItemPriceCommand_PropertiesAreSetCorrectly()
		{
			// Arrange
			var id = Guid.NewGuid();
			var input = new UpdateItemPriceInput { Price = 100 };
			var command = new UpdateItemPriceCommand(id, input);

			// Act
			var resultId = command.Id;
			var resultInput = command.Input;

			// Assert
			Assert.Equal(id, resultId);
			Assert.Equal(input, resultInput);
		}
	}
}
