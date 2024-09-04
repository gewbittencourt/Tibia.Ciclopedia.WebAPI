using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.DeleteItemTests
{
	public class DeleteItemTest
	{
		[Fact]
		public async Task Handle_ValidId_ItemDeletedSuccessfully()
		{
			// Arrange
			var mockRepository = new Mock<IItemRepository>();
			var handler = new DeleteItem(mockRepository.Object);
			var itemId = Guid.NewGuid();
			var request = new DeleteItemInput { Id = itemId };

			mockRepository.Setup(repo => repo.GetByIdItems(itemId, It.IsAny<CancellationToken>()))
						  .ReturnsAsync(new Item());

			mockRepository.Setup(repo => repo.Deletetem(It.IsAny<Item>(), It.IsAny<CancellationToken>()))
						  .ReturnsAsync(true);

			// Act
			var result = await handler.Handle(request, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			mockRepository.Verify(repo => repo.GetByIdItems(itemId, It.IsAny<CancellationToken>()), Times.Once);
			mockRepository.Verify(repo => repo.Deletetem(It.IsAny<Item>(), It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
