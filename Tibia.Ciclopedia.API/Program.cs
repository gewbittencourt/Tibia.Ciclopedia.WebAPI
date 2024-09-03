using Tibia.Ciclopedia.Domain.Interface;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

using Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping;
using MappingItem = Tibia.Ciclopedia.Application.Mapping.MappingItem;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Repository;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;

namespace TibiaItemWebAPI
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAutoMapper(typeof(MappingItem));
			builder.Services.AddAutoMapper(typeof(MappingItemCollection));
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json")
				.Build();

			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

			var mongoclient = new MongoClient(configuration.GetConnectionString("MongoDb"));

			builder.Services.AddSingleton<IMongoClient>(mongoclient);
			builder.Services.AddSingleton(sp =>
			{
				var database = mongoclient.GetDatabase(ItemCollection.CollectionName);
				return database.GetCollection<ItemCollection>(nameof(ItemCollection));
			});

			builder.Services.AddScoped<IItemRepository, ItemRepository>();
			builder.Services.AddScoped<ICreateItemUseCase, CreateItem>();
			builder.Services.AddScoped<IGetAllItemUseCase, GetAllItem>();
			builder.Services.AddScoped<IGetByNameItemsUseCase, GetByNameItems>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
