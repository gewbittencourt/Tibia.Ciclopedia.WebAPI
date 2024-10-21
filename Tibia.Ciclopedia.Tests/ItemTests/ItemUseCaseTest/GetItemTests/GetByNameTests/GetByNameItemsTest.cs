using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.CrossCutting;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetByName
{
    public class GetByNameItemsTest
	{
		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly GetItemsByName _getByNameItemsUseCase;
		private readonly Mock<ICrossCutting> _mockCrossCutting;

		public GetByNameItemsTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_mockCrossCutting = new Mock<ICrossCutting>();
			_getByNameItemsUseCase = new GetItemsByName(_mockItemRepository.Object, _mockCrossCutting.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccessOutputWithItem_WhenItemExists()
		{
			// Arrange
			var item = new Item
			{
			};

			_mockItemRepository
				.Setup(repo => repo.GetItemsByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(item);

			var input = new GetByNameItemsInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByNameItemsUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsValid);
			Assert.Equal(item, result.Result);
		}


		[Fact]
		public async Task Handle_ShouldReturnFailureOutput_WhenNoItemExists()
		{
			// Arrange
			_mockItemRepository
				.Setup(repo => repo.GetItemsByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync((Item)null);

			var input = new GetByNameItemsInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByNameItemsUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.False(result.IsValid);
			Assert.Equal("Item não encontrado", result.Errors.First());
		}
	}
}
