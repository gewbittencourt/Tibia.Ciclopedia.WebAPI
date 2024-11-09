using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.UpdateItem;

namespace Tibia.Ciclopedia.Tests.ItemTests.ItemUseCaseTest.UpdateItemTest.UpdateAllTest
{
    public class UpdateAllItemTest
	{
		private readonly Mock<IItemRepository> _mockItemRepository;
		private readonly UpdateItem _updateAllItem;

		public UpdateAllItemTest()
		{
			_mockItemRepository = new Mock<IItemRepository>();
			_updateAllItem = new UpdateItem(_mockItemRepository.Object, null);  // O segundo argumento (mapper) é null, se não for usado
		}

		[Fact]
		public async Task Handle_Should_UpdateAllItem_When_ItemExists()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var input = new UpdateItemInput
			{
				Id = itemId,
				Name = "ItemName",
				Type = ItemType.Helmet,
				Vocations = Vocations.Druid,
				LevelRequired = 10,
				Slots = new SlotsInfoItem(true, 1),
				Image = "image_path"
			};

			var item = new Item();  // Criação de um objeto Item real

			// Setup para retorno do item a partir do repositório
			_mockItemRepository.Setup(repo => repo.GetItemById(itemId, It.IsAny<CancellationToken>()))
				.ReturnsAsync(item);

			// Setup para o método de atualização
			_mockItemRepository.Setup(repo => repo.UpdateItem(item, It.IsAny<CancellationToken>()))
				.ReturnsAsync(true);

			// Act
			var result = await _updateAllItem.Handle(input, CancellationToken.None);

			// Assert
			Assert.True(result.IsValid);
			_mockItemRepository.Verify(i => i.UpdateItem(item, It.IsAny<CancellationToken>()), Times.Once);  // Verifica se o método correto foi chamado
		}
	}

}