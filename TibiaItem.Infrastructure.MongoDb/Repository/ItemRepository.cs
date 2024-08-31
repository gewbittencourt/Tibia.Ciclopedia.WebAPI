using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Domain.Entities;
using TibiaItem.Domain.Interface;
using TibiaItem.Infrastructure.MongoDb.Collection;

namespace TibiaItem.Infrastructure.Repository
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
	}
}
