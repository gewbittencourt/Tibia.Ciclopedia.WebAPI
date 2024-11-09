using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.DeleteItem;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.DeleteItemTests
{
	public class DeleteItemInputTest
	{

		[Fact]
		public void DeleteItemInput_IdIsSetCorrectly()
		{
			// Arrange
			var id = Guid.NewGuid();
			var deleteItemInput = new DeleteItemInput { Id = id };

			// Act
			var result = deleteItemInput.Id;

			// Assert
			Assert.Equal(id, result);
		}
	}
}
