using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;
using Microsoft.Extensions.Configuration;
using Tibia.Ciclopedia.Domain.Interface;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using System.Reflection;


namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Module
{
	public static class InfrastructureModule
	{

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


		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IItemRepository, ItemRepository>();
			services.AddScoped<ICreateItemUseCase, CreateItem>();
			services.AddScoped<IGetAllItemUseCase, GetAllItem>();
			services.AddScoped<IGetByNameItemsUseCase, GetByNameItems>();
			services.AddScoped<IUpdateItemPriceUseCase, UpdateItemPrice>();
			services.AddScoped<IUpdateAllItemUseCase, UpdateAllItem>();
			services.AddScoped<IDeleteItemUseCase, DeleteItem>();

			return services;
		}
	}
}
