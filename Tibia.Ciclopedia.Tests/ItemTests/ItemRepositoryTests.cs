using AutoMapper;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using static System.Reflection.Metadata.BlobBuilder;
using Xunit.Sdk;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Linq;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Builder;

namespace Tibia.Ciclopedia.Tests.ItemTests
{
	public class ItemRepositoryTests
	{
		private readonly IItemRepository _itemRepository;
		private readonly Mock<IMongoClient> _mockMongoClient;
		private readonly Mock<IMapper> _mockMapper;
		private readonly Mock<IAsyncCursor<ItemCollection>> _mockCursor;
		private readonly Mock<IMongoDatabase> _mockDatabase;
		private readonly Mock<IMongoCollection<ItemCollection>> _mockMongoCollection;

		public ItemRepositoryTests()
		{
			_mockMongoClient = new Mock<IMongoClient>();
			_mockMapper = new Mock<IMapper>();
			_mockCursor = new Mock<IAsyncCursor<ItemCollection>>();
			_mockDatabase = new Mock<IMongoDatabase>();
			_mockMongoCollection = new Mock<IMongoCollection<ItemCollection>>();


			_mockMongoClient.Setup(client => client.GetDatabase("ItemCollection", null))
							.Returns(_mockDatabase.Object);
			_mockDatabase.Setup(db => db.GetCollection<ItemCollection>(nameof(ItemCollection), null))
							 .Returns(_mockMongoCollection.Object);

			_itemRepository = new ItemRepository(_mockMongoCollection.Object, _mockMapper.Object);
		}



		[Fact]
		public async Task CreateNewItem_ShouldInsertItemIntoCollection_WhenSuccessfull()
		{
			// Arrange
			var item = new Item();
			var itemCollection = new ItemCollection();
			_mockMapper.Setup(m => m.Map<ItemCollection>(item)).Returns(itemCollection);
			_mockMongoCollection.Setup(i => i.InsertOneAsync(itemCollection, new InsertOneOptions(), It.IsAny<CancellationToken>()))
							   .Returns(Task.CompletedTask);

			// Act
			await _itemRepository.CreateNewItem(item, CancellationToken.None);


			// Assert
			_mockMapper.Verify(m => m.Map<ItemCollection>(item), Times.Once);
			_mockMongoCollection.Verify(i => i.InsertOneAsync(itemCollection, It.IsAny<InsertOneOptions>(), It.IsAny<CancellationToken>()), Times.Once);
		}




		[Fact]
		public async Task GetAllItems_ReturnsList_WhenSuccessfull()
		{
			// Arrange
			var cancellationToken = new CancellationToken();
			var items = new List<ItemCollection> {

				new ItemCollection{Name = "test", PurchasePrice = 100},
				new ItemCollection{Name = "test2", PurchasePrice = 200}
			};

			//SIMULAÇÃO DO FIND
			_mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
			_mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true).ReturnsAsync(false);
			_mockCursor.Setup(x => x.Current).Returns(items);

			_mockMongoCollection.Setup(x => x.FindAsync(
				It.IsAny<FilterDefinition<ItemCollection>>(),
				It.IsAny<FindOptions<ItemCollection, ItemCollection>>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(_mockCursor.Object);

			// Act
			var result = await _itemRepository.GetAllItems(cancellationToken);

			// Assert
			Assert.IsType<Item[]>(result);
		}


		[Fact]
		public async Task GetByNameItems_ReturnsOneItem_WhenSuccessful()
		{
			// Arrange
			var itemCollection = new ItemCollection { Name = "test" };
			var name = "test";
			var item = new Item(name);


			// SIMULAÇÃO DO FIND
			var mockCursor = new Mock<IAsyncCursor<ItemCollection>>();
			mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
			mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true).ReturnsAsync(false);
			mockCursor.Setup(x => x.Current).Returns(new List<ItemCollection> { itemCollection });

			_mockMongoCollection.Setup(x => x.FindAsync(
				It.IsAny<FilterDefinition<ItemCollection>>(),
				It.IsAny<FindOptions<ItemCollection, ItemCollection>>(),
				It.IsAny<CancellationToken>())).ReturnsAsync(mockCursor.Object);

			_mockMapper.Setup(mapper => mapper.Map<Item>(itemCollection))
					   .Returns(item);

			// Act
			var result = await _itemRepository.GetItemByName(name, It.IsAny<CancellationToken>());

			// Assert
			Assert.NotNull(result);
			Assert.IsType<Item>(result);
			Assert.Equal(name, result.Name);
		}



		[Fact]
		public async Task UpdateAll_ReturnsTrue_WhenSuccessful()
		{
			// Arrange
			var item = new Item(name: "test", type: ItemType.Boots, vocations: Vocations.Druid,
								new SlotsInfoItem(true, 1), purchaseprice: 100, sellingprice: 100,
								image: "linktest", levelRequired: 100);

			var itemCollection = new ItemCollection();

			_mockMapper.Setup(m => m.Map<ItemCollection>(item)).Returns(itemCollection);

			var updateResultMock = new Mock<UpdateResult>();
			updateResultMock.Setup(r => r.ModifiedCount).Returns(1);

			_mockMongoCollection.Setup(i => i.UpdateOneAsync(
					It.IsAny<FilterDefinition<ItemCollection>>(),
					It.IsAny<UpdateDefinition<ItemCollection>>(),
					null,
					It.IsAny<CancellationToken>()
				)).ReturnsAsync(updateResultMock.Object);

			// Act
			var result = await _itemRepository.UpdateItem(item, CancellationToken.None);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public async Task DeleteItem_ReturnBool_WhenSuccessfull()
		{
			//Arrange
			var item = new Item();
			var mockResult = new DeleteResult.Acknowledged(1);
			_mockMongoCollection.Setup(mongo => mongo.DeleteOneAsync(It.IsAny<FilterDefinition<ItemCollection>>(), It.IsAny<CancellationToken>())).ReturnsAsync(mockResult);


			//Act
			var result = await _itemRepository.Deletetem(item, It.IsAny<CancellationToken>());


			//Asserts
			Assert.True(result);
		}



	}
}
