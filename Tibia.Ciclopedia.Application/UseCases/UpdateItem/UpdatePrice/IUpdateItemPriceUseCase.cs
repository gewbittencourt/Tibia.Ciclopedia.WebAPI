using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdatePrice;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice
{
	public interface IUpdateItemPriceUseCase : IRequestHandler<UpdateItemPriceCommand, Output<bool>>
	{
	}
}
