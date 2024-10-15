using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Builder;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Repository
{
	public class ItemRepository : IItemRepository
	{

		private readonly IMongoCollection<ItemCollection> _item;
		private readonly IMapper _mapper;


		public ItemRepository(IMongoCollection<ItemCollection> item, IMapper mapper)
		{
			_item = item;
			_mapper = mapper;
		}



		public async Task CreateNewItem(Item item, CancellationToken cancellationToken)
		{
			var itemCollection = _mapper.Map<ItemCollection>(item);
			await _item.InsertOneAsync(itemCollection, new InsertOneOptions(), cancellationToken);

		}

		public async Task<IEnumerable<Item>> GetAllItems(CancellationToken cancellationToken)
		{
			var itemCollection = await _item.Find(_ => true).ToListAsync(cancellationToken);
			return _mapper.Map<IEnumerable<Item>>(itemCollection);
		}



		public async Task<Item> GetItemByName(string name, CancellationToken cancellationToken)
		{
			var filter = Builders<ItemCollection>.Filter.Text($"\"{name}\"");
			var sort = Builders<ItemCollection>.Sort.Ascending(s => s.Name);
			var itemCollection = await _item.Find(filter).Sort(sort).FirstOrDefaultAsync(cancellationToken);
			return _mapper.Map<Item>(itemCollection);
		}


		public async Task<Item> GetItemById(Guid id, CancellationToken cancellationToken)
		{
			var filter = Builders<ItemCollection>.Filter.Eq(x => x.ItemID, id);
			var itemCollection = await _item.Find(filter).FirstOrDefaultAsync(cancellationToken);
			return _mapper.Map<Item>(itemCollection);
		}


		public async Task<bool> UpdateItem(Item item, CancellationToken cancellationToken)
		{
			var filter = Builders<ItemCollection>.Filter.Eq(x => x.ItemID, item.Id);

			var update = ItemUpdateBuilder.CreateUpdate(item);
			var result = await _item.UpdateOneAsync(filter, update, null, cancellationToken);

			return result.ModifiedCount == 1;
		}

		public async Task<bool> Deletetem(Item item, CancellationToken cancellationToken)
		{
			var filter = Builders<ItemCollection>.Filter.Eq(x => x.ItemID, item.Id);
			var result = await _item.DeleteOneAsync(filter, cancellationToken);
			return result.DeletedCount == 1;
		}
	}
}
