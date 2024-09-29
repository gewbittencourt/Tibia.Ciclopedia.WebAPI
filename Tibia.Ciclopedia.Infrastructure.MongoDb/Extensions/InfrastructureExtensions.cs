using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Microsoft.Extensions.Configuration;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using System.Reflection;
using Tibia.Ciclopedia.Domain.Entities;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Module
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddRepositories()
				.AddMongo(configuration)
				.AddIndex();

			return services;
		}

		public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
		{
			var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));

			services.AddSingleton<IMongoClient>(mongoClient);
			services.AddSingleton(sp =>
			{
				var database = mongoClient.GetDatabase(ItemCollection.CollectionName);
				return database.GetCollection<ItemCollection>(ItemCollection.CollectionName);
			});
			return services;
		}

		public static IServiceCollection AddIndex(this IServiceCollection services)
		{
			services.AddSingleton<ItemCollectionIndex>(sp =>
			{
				var mongoClient = sp.GetRequiredService<IMongoClient>();
				var database = mongoClient.GetDatabase(ItemCollection.CollectionName);
				return new ItemCollectionIndex(database);
			});

			return services;
		}

		public static void IndexItemName(this IServiceProvider serviceProvider)
		{
			var itemIndexService = serviceProvider.GetRequiredService<ItemCollectionIndex>();
			itemIndexService.IndexesAsync().Wait();
		}




		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IItemRepository, ItemRepository>();

			return services;
		}
	}
}
