﻿using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Builder;
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

		public async Task<IEnumerable<Monster>> GetAllMonsters(CancellationToken cancellationToken)
		{
			var monsterCollectionList = await _monsterCollection.Find(_ => true).ToListAsync(cancellationToken);
			return _mapper.Map<IEnumerable<Monster>>(monsterCollectionList);
		}


		public async Task<Monster> GetMonsterByName(string name, CancellationToken cancellationToken)
		{
			var filter = Builders<MonsterCollection>.Filter.Text($"\"{name}\"");
			var monsterCollection = await _monsterCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
			return _mapper.Map<Monster>(monsterCollection);
		}

		public async Task<IEnumerable<Monster>> GetMonsterByElementAndDifficulty(string element, MonsterDifficulty difficulty, CancellationToken cancellationToken)
		{
			var difficultyFilter = Builders<MonsterCollection>.Filter.Eq("DifficultyCategory", difficulty);
			var elementWeaknessFilter = Builders<MonsterCollection>.Filter.Gt($"ElementsWeaknessMonster.{element}", 100);
			var combinedFilter = Builders<MonsterCollection>.Filter.And(difficultyFilter, elementWeaknessFilter);
			var monsterCollection = await _monsterCollection.Find(combinedFilter).ToListAsync(cancellationToken);
			return _mapper.Map<IEnumerable<Monster>>(monsterCollection);
		}


		public async Task<Monster> GetMonsterById(Guid id, CancellationToken cancellationToken)
		{
			var filter = Builders<MonsterCollection>.Filter.Eq(x => x.MonsterId, id);
			var monsterCollection = await _monsterCollection.Find(filter).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);	
			return _mapper.Map<Monster>(monsterCollection);
		}

		public async Task<bool> UpdateMonster(Monster monster, CancellationToken cancellationToken)
		{
			var filter = Builders<MonsterCollection>.Filter.Eq(x=>x.MonsterId, monster.Id);
			var monsterUpdate = _mapper.Map<MonsterCollection>(monster);
			var update = MonsterUpdateBuilder.CreateUpdate(monsterUpdate);
			var result = await _monsterCollection.UpdateOneAsync(filter, update, null, cancellationToken);
			return result.ModifiedCount == 1;
		}

		public async Task<bool> DeleteMonster(Guid id, CancellationToken cancellationToken)
		{
			var filter = Builders<MonsterCollection>.Filter.Eq(x=>x.MonsterId, id);
			var result = await _monsterCollection.DeleteOneAsync(filter, cancellationToken);
			return result.DeletedCount == 1;
		}


	}
}
