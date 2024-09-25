using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdatePrice
{
	public class UpdateItemPriceCommand : IRequest<Output<bool>>
	{
		public Guid Id { get; set; }
		public UpdateItemPriceInput Input { get; set; }

		public UpdateItemPriceCommand(Guid id, UpdateItemPriceInput input)
		{
			Id = id;
			Input = input;
		}
	}
}
