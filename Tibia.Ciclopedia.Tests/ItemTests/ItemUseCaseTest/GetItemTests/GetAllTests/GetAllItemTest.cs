using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Domain.Items;
using Xunit.Abstractions;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.GetItemTests.GetAll
{
	public class GetAllItemTest
	{
		
        private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly GetAllItem _getAllItemUseCase;

		public GetAllItemTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_getAllItemUseCase = new GetAllItem(_mockItemRepository.Object);
		}

		[Fact]
		public async Task Handle_ShouldReturnSuccessOutputWithItems()
		{
			// Arrange
			var items = new List<Item>
			{
				new Item(),
				new Item()
			};

			_mockItemRepository
				.Setup(repo => repo.GetAllItems(It.IsAny<CancellationToken>()))
				.ReturnsAsync(items);

			var input = new GetAllItemInput();
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getAllItemUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsValid);
			Assert.Equal(items, result.Result);
		}

		[Fact]
		public async Task Handle_ShouldReturnEmptyOutputWhenNoItems()
		{
			// Arrange
			_mockItemRepository
				.Setup(repo => repo.GetAllItems(It.IsAny<CancellationToken>()))
				.ReturnsAsync(new List<Item>());

			var input = new GetAllItemInput();
			var cancellationToken = CancellationToken.None;

			// Act
			var result = await _getAllItemUseCase.Handle(input, cancellationToken);

			// Assert
			Assert.NotNull(result);
			Assert.True(result.IsValid);
			Assert.Empty(result.Result);
		}
	}
}
