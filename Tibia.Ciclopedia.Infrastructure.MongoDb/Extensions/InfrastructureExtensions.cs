using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Microsoft.Extensions.Configuration;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using System.Reflection;


namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Module
{
	public static class InfrastructureExtensions
	{

		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddRepositories()
				.AddMongo(configuration);

			return services;
		}

		public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
		{
			var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));

			services.AddSingleton<IMongoClient>(mongoClient);
			services.AddSingleton(sp =>
			{
				var database = mongoClient.GetDatabase(ItemCollection.CollectionName);
				return database.GetCollection<ItemCollection>(nameof(ItemCollection));
			});

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IItemRepository, ItemRepository>();

			return services;
		}
	}
}
