using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetByName
{
	public class GetByNameItemsTest
	{
		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly GetByNameItems _getByNameItemsUseCase;

		public GetByNameItemsTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_getByNameItemsUseCase = new GetByNameItems(_mockItemRepository.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccessOutputWithItems_WhenItemsExist()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item(),
				new Item()
			};

			_mockItemRepository
				.Setup(repo => repo.GetByNameItems(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(items);

			var input = new GetByNameItemsInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByNameItemsUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsValid);
			Assert.Equal(items, result.Result);
		}

		[Fact]
		public async Task Handle_ShouldReturnEmptyOutput_WhenNoItemsExist()
		{
			// Arrange
			_mockItemRepository
				.Setup(repo => repo.GetByNameItems(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(new List<Item>());

			var input = new GetByNameItemsInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByNameItemsUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsValid);
			Assert.Empty(result.Result);
		}
	}
}
