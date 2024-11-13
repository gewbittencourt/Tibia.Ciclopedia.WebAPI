using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tibia.Ciclopedia.Application.BaseOutput;
using TibiaItem.API.Controllers;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.UpdateItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.DeleteItem;

namespace Tibia.Ciclopedia.Tests.ItemTests
{
    public class ItemControllerTests
	{
		private readonly Mock<IMediator> _mediatorMock;
		private readonly ItemController _controller;

		public ItemControllerTests()
		{
			_mediatorMock = new Mock<IMediator>();
			_controller = new ItemController(_mediatorMock.Object);
		}

		[Fact]
		public async Task Create_ReturnsOkResult_WithExpectedResult()
		{
			// Arrange
			var request = new CreateItemInput();
			var expectedResponse = Output<Guid>.Success(Guid.NewGuid());

			_mediatorMock.Setup(m => m.Send(It.IsAny<CreateItemInput>(), default))
						 .ReturnsAsync(expectedResponse);

			// ActS
			var result = await _controller.Create(request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}


		[Fact]
		public async Task GetAll_ReturnsOkResult_WithListOfItems()
		{
			// Arrange
			var expectedItems = new List<Item>();
			var expectedResponse = Output<IEnumerable<Item>>.Success(expectedItems);

			_mediatorMock.Setup(mediator => mediator.Send(It.IsAny<GetAllItemInput>(), It.IsAny<CancellationToken>()))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.GetAll();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var actualResult = Assert.IsType<Output<IEnumerable<Item>>>(okResult.Value);
			Assert.True(actualResult.IsValid);
			Assert.Equal(expectedItems, actualResult.Result);
		}


		[Fact]
		public async Task GetByName_ReturnsOkResult_WithListOfItems()
		{
			// Arrange
			var request = new GetItemByNameInput { Name = "TestItem" };
			var itemlist = new Item();
			{
				new Item(name: "test", type: ItemType.Boots, vocations: Vocations.Druid, new SlotsInfoItem(true, 1), purchaseprice: 100, sellingprice: 100, image: "linktest", levelRequired: 100);
			}
			var expectedResponse = Output<Item>.Success(itemlist);

			_mediatorMock.Setup(mediator => mediator.Send(request, It.IsAny<CancellationToken>()))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.GetByName(request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}


		[Fact]
		public async Task UpdateItem_ShouldReturnOkResult()
		{
			// Arrange
			var id = Guid.NewGuid();
			var expectedResponse = Output<bool>.Success(true);
			var request = new UpdateItemInput { Id = id };
			_mediatorMock.Setup(m => m.Send(It.IsAny<UpdateItemInput>(), default))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.UpdateItem(id, request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}

		[Fact]
		public async Task DeleteItem_ShouldReturnOkResult()
		{
			// Arrange
			var id = new Guid();
			var request = new DeleteItemInput { Id = id };
			var expectedResponse = Output<bool>.Success(true);
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(expectedResponse);

			//Act
			var result = await _controller.Delete(request);

			// Asserts
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}
	}
}
