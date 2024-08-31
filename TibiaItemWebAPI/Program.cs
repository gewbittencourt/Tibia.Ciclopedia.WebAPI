
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using TibiaItem.Domain.Interface;
using TibiaItem.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using TibiaItem.Infrastructure.MongoDb.Collection;
using TibiaItem.Application.Mapping;

using TibiaItem.Infrastructure.MongoDb.Mapping;

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
			builder.Services.AddAutoMapper(typeof(MappingEntitie));
			builder.Services.AddAutoMapper(typeof(MappingCollection));
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
