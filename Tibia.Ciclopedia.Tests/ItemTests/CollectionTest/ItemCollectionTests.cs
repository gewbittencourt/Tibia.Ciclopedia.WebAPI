using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Tests.ItemTests.CollectionTest
{
	public class ItemCollectionTests
	{
		[Fact]
		public void ItemCollection_Should_SetAndRetrieveProperties()
		{
			// Arrange
			var itemId = Guid.NewGuid();
			var itemName = "Test Item";
			var slug = "test-item";
			var itemType = ItemType.Bow;
			var vocations = Vocations.Knight;
			var levelRequired = 10;
			var sellingPrice = 150.5;
			var purchasePrice = 200.0;
			var createdAt = DateTime.Now;
			var updatedAt = DateTime.Now;
			var imageLink = "http://example.com/image.png";

			var itemCollection = new ItemCollection
			{
				Id = ObjectId.GenerateNewId(),
				ItemID = itemId,
				Name = itemName,
				Slug = slug,
				Type = itemType,
				Vocations = vocations,
				LevelRequired = levelRequired,
				SellingPrice = sellingPrice,
				PurchasePrice = purchasePrice,
				CreatedAt = createdAt,
				UpdatedAt = updatedAt,
				Image = imageLink
			};

			// Act & Assert
			Assert.NotNull(itemCollection.Id);
			Assert.Equal(itemId, itemCollection.ItemID);
			Assert.Equal(itemName, itemCollection.Name);
			Assert.Equal(slug, itemCollection.Slug);
			Assert.Equal(itemType, itemCollection.Type);
			Assert.Equal(vocations, itemCollection.Vocations);
			Assert.Equal(levelRequired, itemCollection.LevelRequired);
			Assert.Equal(sellingPrice, itemCollection.SellingPrice);
			Assert.Equal(purchasePrice, itemCollection.PurchasePrice);
			Assert.Equal(createdAt, itemCollection.CreatedAt);
			Assert.Equal(updatedAt, itemCollection.UpdatedAt);
			Assert.Equal(imageLink, itemCollection.Image);
		}
	}
}
