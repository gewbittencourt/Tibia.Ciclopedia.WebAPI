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
	public class UpdateAllItemCommand : IRequest<Output<bool>>
	{
		public Guid Id { get; }
		public UpdateAllItemInput Input { get; }

		public UpdateAllItemCommand(Guid id, UpdateAllItemInput input)
		{
			Id = id;
			Input = input;
		}
	}
}
