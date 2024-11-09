using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetByName
{
	public class GetByNameItemsInputTest
	{
		[Fact]
		public void GetByNameItemsInput_ShouldSetNameProperty()
		{
			// Arrange
			var name = "test";

			// Act
			var input = new GetItemByNameInput
			{
				Name = name
			};

			// Assert
			Assert.Equal(name, input.Name);
		}

		[Fact]
		public void GetByNameItemsInput_ShouldImplementIRequestWithOutputOfIEnumerableItem()
		{
			// Arrange
			var input = new GetItemByNameInput();

			// Act & Assert
			Assert.IsAssignableFrom<IRequest<Output<Item>>>(input);
		}
	}
}
