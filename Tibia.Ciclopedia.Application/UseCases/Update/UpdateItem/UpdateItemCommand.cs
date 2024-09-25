using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAll
{
	public class UpdateItemCommand : IRequest<Output<bool>>
	{
		public Guid Id { get; }
		public UpdateItemInput Input { get; }

		public UpdateItemCommand(Guid id, UpdateItemInput input)
		{
			Id = id;
			Input = input;
		}
	}
}
