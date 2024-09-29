using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection
{
	public class ItemCollectionIndex
	{
		private readonly IMongoCollection<ItemCollection> _itemCollection;

		public ItemCollectionIndex(IMongoDatabase database)
		{
			_itemCollection = database.GetCollection<ItemCollection>(ItemCollection.CollectionName);
		}

		private void CreateIndex()
		{
			var indexModel = new CreateIndexModel<ItemCollection>(Builders<ItemCollection>.IndexKeys.Ascending(m => m.Name));
			_itemCollection.Indexes.CreateOne(indexModel);
		}

		public async Task EnsureIndexesAsync()
		{
			CreateIndex();
		}
	}
}
