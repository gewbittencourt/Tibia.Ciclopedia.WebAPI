using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdatePriceTest
{
	public class UpdateItemPriceTest
	{

		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly UpdateItemPrice _updateItemPriceUseCase;

		public UpdateItemPriceTest()
		{


			_mockItemRepository = new Mock<IItemRepository>();
			_updateItemPriceUseCase = new UpdateItemPrice(_mockItemRepository.Object, null);
		}

		[Fact]
		public async Task Handle_Should_UpdateItemPrice_When_ItemExists()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var newPrice = 49.99;
			var item = new Item();

			item.UpdatePriceItem(It.IsAny<double>());
			_mockItemRepository.Setup(repo => repo.GetByIdItems(itemId, It.IsAny<CancellationToken>()))
				.ReturnsAsync(item);

			_mockItemRepository.Setup(repo => repo.UpdateItemPrice(item, It.IsAny<CancellationToken>()))
			.ReturnsAsync(true);

			var input = new UpdateItemPriceInput
			{
				Id = itemId,
				Price = newPrice
			};

			// Act
			var result = await _updateItemPriceUseCase.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.Equal(item.Price, newPrice);
			_mockItemRepository.Verify(repo => repo.UpdateItemPrice(item, It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
