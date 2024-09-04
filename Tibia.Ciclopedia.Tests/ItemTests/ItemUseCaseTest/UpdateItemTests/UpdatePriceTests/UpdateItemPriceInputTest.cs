using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdatePriceTest
{
	public class UpdateItemPriceInputTest
	{
		[Fact]
		public void UpdateItemPriceInput_Should_Have_Valid_Properties()
		{
			// Arrange
			var id = Guid.NewGuid();
			var price = 29.99;

			// Act
			var input = new UpdateItemPriceInput
			{
				Price = price
			};

			// Assert
			Assert.Equal(price, input.Price);
		}
	}
}
