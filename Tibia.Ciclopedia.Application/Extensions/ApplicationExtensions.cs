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
using Tibia.Ciclopedia.Application.UseCases.Update.UpdateItem;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.CrossCutting;

namespace Tibia.Ciclopedia.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateItemUseCase, CreateItem>();
            services.AddScoped<IGetAllItemsUseCase, GetAllItem>();
            services.AddScoped<IGetItemsByNameUseCase, GetItemsByName>();
            services.AddScoped<IUpdateItemUseCase, UpdateItem>();
            services.AddScoped<IDeleteItemUseCase, DeleteItem>();
			services.AddHttpClient<ICrossCutting, CrossCutting>();


			return services;
        }
    }
}