using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Repository
{
	public class MonsterRepository : IMonsterRepository
	{

		private readonly IMongoCollection<MonsterCollection> _monsterCollection;
		private readonly IMapper _mapper;

		public MonsterRepository(IMongoCollection<MonsterCollection> monsterCollection, IMapper mapper)
		{
			_monsterCollection = monsterCollection;
			_mapper = mapper;
		}

		public async Task CreateNewMonster(Monster monster, CancellationToken cancellationToken)
		{
			var itemCollection = _mapper.Map<MonsterCollection>(monster);
			await _monsterCollection.InsertOneAsync(itemCollection, new InsertOneOptions(), cancellationToken);

		}
	}
}
