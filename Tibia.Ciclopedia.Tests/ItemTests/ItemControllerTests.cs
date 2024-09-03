using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;
using TibiaItem.API.Controllers;

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
			var expectedResponse = Output<bool>.Success(true);

			_mediatorMock.Setup(m => m.Send(It.IsAny<CreateItemInput>(), default))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.Create(request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}

		[Fact]
		public async Task GetAll_ReturnsOkResult_WithListOfItems()
		{
			// Arrange

			var expectedResponse = Output<IEnumerable<Item>>.Success(new List<Item>());


			_mediatorMock.Setup(mediator => mediator.Send(new GetAllItemInput(), It.IsAny<CancellationToken>()))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.GetAll();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
		}


		[Fact]
		public async Task GetByName_ReturnsOkResult_WithListOfItems()
		{
			// Arrange
			var request = new GetByNameItemsInput { Name = "TestItem" };
			var itemlist = new List<Item>
			{
				 new Item(name: "test", type: ItemType.Boots.ToString(), vocations: Vocations.Druid.ToString(), new SlotsInfo { HaveSlots = true, Quantity = 1 }, price: 100, image: "linktest")
			};
			var expectedResponse = Output<IEnumerable<Item>>.Success(itemlist);

			_mediatorMock.Setup(mediator => mediator.Send(request, It.IsAny<CancellationToken>()))
						 .ReturnsAsync(expectedResponse);

			// Act
			var result = await _controller.GetByName(request);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			Assert.Equal(expectedResponse, okResult.Value);
		}
	}
}
