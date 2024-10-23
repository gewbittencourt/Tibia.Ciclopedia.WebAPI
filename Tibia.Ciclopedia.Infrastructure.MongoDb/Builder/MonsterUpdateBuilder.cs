using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Builder
{
	public class MonsterUpdateBuilder
	{
		public static UpdateDefinition<MonsterCollection> CreateUpdate(MonsterCollection monster)
		{
			var update = Builders<MonsterCollection>.Update;

			return update
				.Set(x => x.Name, monster.Name)
				.Set(x => x.DifficultyCategory, monster.DifficultyCategory)
				.Set(x => x.Experience, monster.Experience)
				.Set(x => x.HitPoints, monster.HitPoints);
		}
	}
}
