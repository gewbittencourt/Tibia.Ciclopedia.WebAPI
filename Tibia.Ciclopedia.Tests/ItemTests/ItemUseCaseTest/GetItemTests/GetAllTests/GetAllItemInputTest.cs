using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetAll;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetAll
{
	public class GetAllItemInputTest
	{
		[Fact]
		public void GetAllItemInput_ShouldImplementIRequest()
		{
			// Arrange
			var getAllItemInput = new GetAllItemInput();

			// Act & Assert
			Assert.IsAssignableFrom<IRequest<Output<IEnumerable<Item>>>>(getAllItemInput);
		}
	}
}

