using Tibia.Ciclopedia.Domain.Items;
using MongoDB.Driver;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection;

using Tibia.Ciclopedia.Infrastructure.MongoDb.Mapping;
using MappingItem = Tibia.Ciclopedia.Application.Mapping.MappingItem;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Module;
using Tibia.Ciclopedia.Application.Extensions;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.Extensions;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.Mapping;
using Tibia.Ciclopedia.Application.Mapping;

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
			builder.Services.AddAutoMapper(typeof(MappingItemMarketPrice));
			builder.Services.AddAutoMapper(typeof(MappingItemCollection));
			builder.Services.AddAutoMapper(typeof(MappingMonster));
			builder.Services.AddAutoMapper(typeof(MappingMonsterCollection));
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json")
				.Build();

			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));



			builder.Services.AddInfrastructure(configuration)
							.AddServices()
							.AddCrossCutting(configuration);


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
