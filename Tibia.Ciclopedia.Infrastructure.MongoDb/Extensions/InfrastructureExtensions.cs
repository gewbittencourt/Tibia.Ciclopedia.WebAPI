using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Microsoft.Extensions.Configuration;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using System.Reflection;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Module
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddRepositories()
				.AddMongoItem(configuration)
				.AddMongoMonster(configuration);

			return services;
		}

		public static IServiceCollection AddMongoItem(this IServiceCollection services, IConfiguration configuration)
		{
			var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));

			services.AddSingleton<IMongoClient>(mongoClient);
			services.AddSingleton(sp =>
			{
				var database = mongoClient.GetDatabase(ItemCollection.CollectionName);
				var itemCollection = database.GetCollection<ItemCollection>(ItemCollection.CollectionName);
				AddIndex(itemCollection, Builders<ItemCollection>.IndexKeys.Text(x => x.Slug));
				return itemCollection;
			});

			return services;
		}


		public static IServiceCollection AddMongoMonster(this IServiceCollection services, IConfiguration configuration)
		{
			var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));

			services.AddSingleton<IMongoClient>(mongoClient);
			services.AddSingleton(sp =>
			{
				var database = mongoClient.GetDatabase(MonsterCollection.CollectionName);
				var monsterCollection = database.GetCollection<MonsterCollection>(MonsterCollection.CollectionName);
				AddIndex(monsterCollection, Builders<MonsterCollection>.IndexKeys.Text(x => x.Name));
				return monsterCollection;
			});

			return services;
		}

		private static void AddIndex<T>(IMongoCollection<T> collection, IndexKeysDefinition<T> indexKeysDefinition)
		{
			var indexModel = new CreateIndexModel<T>(indexKeysDefinition);
			collection.Indexes.CreateOne(indexModel);
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IItemRepository, ItemRepository>();
			services.AddScoped<IMonsterRepository, MonsterRepository>();
			return services;
		}
	}
}
