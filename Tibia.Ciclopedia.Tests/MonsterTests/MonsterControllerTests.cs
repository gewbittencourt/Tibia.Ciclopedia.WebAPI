using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tibia.Ciclopedia.API.Controllers;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.UpdateMonster;
using Xunit;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Tests.MonsterTests
{
	public class MonsterControllerTests
	{
		private readonly Mock<IMediator> _mediatorMock;
		private readonly MonsterController _controller;

		public MonsterControllerTests()
		{
			_mediatorMock = new Mock<IMediator>();
			_controller = new MonsterController(_mediatorMock.Object);
		}

		[Fact]
		public async Task Create_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var request = new CreateMonsterInput();
			var response = new Output<Guid> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Create(request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task Create_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var request = new CreateMonsterInput();
			var response = new Output<Guid> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Create(request);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task GetAll_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var response = new Output<IEnumerable<Ciclopedia.Domain.Monsters.Monster>> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetAllMonsterInput>(), default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetAll();

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task GetAll_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var response = new Output<IEnumerable<Ciclopedia.Domain.Monsters.Monster>> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetAllMonsterInput>(), default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetAll();

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task GetByName_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var request = new GetMonsterByNameInput();
			var response = new Output<Ciclopedia.Domain.Monsters.Monster> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetByName(request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task GetByName_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var request = new GetMonsterByNameInput();
			var response = new Output<Ciclopedia.Domain.Monsters.Monster> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetByName(request);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task GetByElementAndDifficulty_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var request = new GetMonsterByWeaknessAndDifficultyInput();
			var response = new Output<IEnumerable<Ciclopedia.Domain.Monsters.Monster>> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetByElementAndDifficulty(request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task GetByElementAndDifficulty_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var request = new GetMonsterByWeaknessAndDifficultyInput();
			var response = new Output<IEnumerable<Ciclopedia.Domain.Monsters.Monster>> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.GetByElementAndDifficulty(request);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task Delete_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var request = new DeleteMonsterInput();
			var response = new Output<bool> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Delete(request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task Delete_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var request = new DeleteMonsterInput();
			var response = new Output<bool> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Delete(request);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}

		[Fact]
		public async Task Update_ShouldReturnOk_WhenRequestIsValid()
		{
			// Arrange
			var id = Guid.NewGuid();
			var request = new UpdateMonsterInput { Id = id };
			var response = new Output<bool> { IsValid = true };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Update(id, request);

			// Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task Update_ShouldReturnBadRequest_WhenRequestIsInvalid()
		{
			// Arrange
			var id = Guid.NewGuid();
			var request = new UpdateMonsterInput { Id = id };
			var response = new Output<bool> { IsValid = false, Errors = new List<string> { "Error" } };
			_mediatorMock.Setup(m => m.Send(request, default)).ReturnsAsync(response);

			// Act
			var result = await _controller.Update(id, request);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);
		}
	}
}
