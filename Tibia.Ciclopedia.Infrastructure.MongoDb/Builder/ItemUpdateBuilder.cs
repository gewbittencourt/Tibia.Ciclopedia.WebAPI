using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Builder
{
	public class ItemUpdateBuilder
	{
		public static UpdateDefinition<ItemCollection> CreateUpdate(Item item)
		{
			var update = Builders<ItemCollection>.Update;

			return update
				.Set(x => x.Name, item.Name)
				.Set(x => x.Slug, item.Slug)
				.Set(x => x.Type, item.Type)
				.Set(x => x.Vocations, item.Vocations)
				.Set(x => x.LevelRequired, item.LevelRequired)
				.Set(x => x.Slots, item.Slots)
				.Set(x => x.Price, item.Price)
				.Set(x => x.Image, item.Image)
				.Set(x => x.UpdatedAt, item.UpdatedAt)
				.Set(x => x.Period, item.Period);
		}
	}
}
