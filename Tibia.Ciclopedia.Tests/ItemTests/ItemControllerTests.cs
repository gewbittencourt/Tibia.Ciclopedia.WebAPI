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
	}
}
