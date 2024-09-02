using AutoMapper;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace Tibia.Ciclopedia.Tests.ItemTests
{
	public class ItemRepositoryTests
	{
		private readonly Mock<IMongoCollection<ItemCollection>> _itemCollectionMock;
		private readonly Mock<IMapper> _mapperMock;
		private readonly ItemRepository _itemRepository;

		public ItemRepositoryTests()
		{
			_itemCollectionMock = new Mock<IMongoCollection<ItemCollection>>();
			_mapperMock = new Mock<IMapper>();
			_itemRepository = new ItemRepository(_itemCollectionMock.Object, _mapperMock.Object);
		}

		[Fact]
		public async Task CreateNewItem_ShouldInsertMappedItemIntoCollection()
		{
			// Arrange
			var item = new Item();
			var itemCollection = new ItemCollection();
			_mapperMock.Setup(m => m.Map<ItemCollection>(item)).Returns(itemCollection);
			_itemCollectionMock.Setup(i => i.InsertOneAsync(itemCollection, new InsertOneOptions(), It.IsAny<CancellationToken>()))
							   .Returns(Task.CompletedTask);

			// Act
			await _itemRepository.CreateNewItem(item, CancellationToken.None);


			// Assert
			_mapperMock.Verify(m => m.Map<ItemCollection>(item), Times.Once);
			_itemCollectionMock.Verify(i => i.InsertOneAsync(itemCollection, It.IsAny<InsertOneOptions>(), It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
