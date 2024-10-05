using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAll;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdateAllTest
{
	public class UpdateAllItemTest
	{
		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly UpdateItem _updateAllItem;

		public UpdateAllItemTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_updateAllItem = new UpdateItem(_mockItemRepository.Object, null);
		}

		[Fact]
		public async Task Handle_Should_UpdateAllItem_When_ItemExists()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var input = new UpdateItemInput
			{
				Name = "ItemName",
				Type = ItemType.Helmet,
				Vocations = Vocations.Druid,
				LevelRequired = 10,
				Slots = new SlotsInfo(),
				Price = 99.99,
				Image = "image_path"
			};

			var item = new Item();

			item.UpdateAllItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SlotsInfo>(), It.IsAny<string>(), It.IsAny<int>());
			item.UpdatePriceItem(It.IsAny<double>());

			_mockItemRepository.Setup(repo => repo.GetByIdItems(itemId, It.IsAny<CancellationToken>()))
				.ReturnsAsync(item);
			_mockItemRepository.Setup(repo => repo.UpdateAllItem(item, It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);

			var command = new UpdateItemCommand(itemId, input);

			// Act
			var result = await _updateAllItem.Handle(command, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			_mockItemRepository.Verify(i => i.UpdateAllItem(item, CancellationToken.None), Times.Once);
		}
	}
}