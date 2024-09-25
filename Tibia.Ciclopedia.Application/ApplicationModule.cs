using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application
{
	public static class ApplicationModule
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICreateItemUseCase, CreateItem>();
			services.AddScoped<IGetAllItemUseCase, GetAllItem>();
			services.AddScoped<IGetByNameItemsUseCase, GetByNameItems>();
			services.AddScoped<IUpdateItemUseCase, UpdateItem>();
			services.AddScoped<IDeleteItemUseCase, DeleteItem>();

			return services;
		}
	}
}