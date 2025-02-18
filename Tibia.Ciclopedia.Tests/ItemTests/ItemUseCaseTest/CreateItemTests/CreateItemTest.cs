using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.CreateItemTests
{
    public class CreateItemTest
	{
		private readonly Mock<IItemRepository> _itemRepositoryMock;
		private readonly Mock<IMapper> _mapperMock;
		private readonly CreateItem _createItemUseCase;

		public CreateItemTest()
		{
			_itemRepositoryMock = new Mock<IItemRepository>();
			_mapperMock = new Mock<IMapper>();
			_createItemUseCase = new CreateItem(_itemRepositoryMock.Object, _mapperMock.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccess_WhenItemIsCreated()
		{
			// Arrange
			var request = new CreateItemInput
			{
				Name = "name",
				LevelRequired = 0,
				Slots = new SlotsInfoItem(true,0 ),
				Type = ItemType.Armor,
				Vocations = Vocations.Knight,
				Image = "linktest"
			};

			var item = new Item("name");

			_mapperMock.Setup(mapper => mapper.Map<Item>(request)).Returns(item);
			_itemRepositoryMock.Setup(r => r.CreateNewItem(item, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

			// Act
			var result = await _createItemUseCase.Handle(request, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			Assert.IsType<Guid>(result.Result);

			_mapperMock.Verify(m => m.Map<Item>(request), Times.Once);
			_itemRepositoryMock.Verify(r => r.CreateNewItem(item, It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}