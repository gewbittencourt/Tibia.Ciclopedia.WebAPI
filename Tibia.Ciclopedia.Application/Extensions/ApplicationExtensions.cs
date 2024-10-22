using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.DeleteItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.UpdateItem;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName;
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
            services.AddScoped<IGetItemByNameUseCase, GetItemsByName>();
            services.AddScoped<IUpdateItemUseCase, UpdateItem>();
            services.AddScoped<IDeleteItemUseCase, DeleteItem>();
			services.AddScoped<ICreateMonsterUseCase, CreateMonster>();
			services.AddScoped<IGetAllMonstersUseCase, GetAllMonsters>();
            services.AddScoped<IGetMonsterByNameUseCase, GetMonsterByName>();
            services.AddScoped<IDeleteMonsterUseCase, DeleteMonster>();


			return services;
        }
    }
}