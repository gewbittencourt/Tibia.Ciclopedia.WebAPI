﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetAll
{
    public interface IGetAllItemsUseCase : IRequestHandler<GetAllItemInput, Output<IEnumerable<Item>>>
    {
    }
}
