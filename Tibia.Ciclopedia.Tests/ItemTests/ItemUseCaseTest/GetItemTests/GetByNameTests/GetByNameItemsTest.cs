using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.CrossCutting;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetByName
{
	public class GetByNameItemsTest
	{
		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly GetItemsByName _getByItemByNameUseCase;
		private readonly Mock<IMarketService> _mockCrossCutting;

		public GetByNameItemsTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_mockCrossCutting = new Mock<IMarketService>();
			_getByItemByNameUseCase = new GetItemsByName(_mockItemRepository.Object, _mockCrossCutting.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccessOutputWithItem_WhenItemExists()
		{
			// Arrange
			var item = new Item
			{
			};
			item.UpdatePriceItem(100);

			_mockItemRepository
				.Setup(repo => repo.GetItemByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(item);
			

			var input = new GetItemByNameInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByItemByNameUseCase.Handle(input, cancellationToken);

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
				.Setup(repo => repo.GetItemByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync((Item)null);

			var input = new GetItemByNameInput { Name = "test" };
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getByItemByNameUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.False(result.IsValid);
			Assert.Equal("Item não encontrado", result.Errors.First());
		}
	}
}
