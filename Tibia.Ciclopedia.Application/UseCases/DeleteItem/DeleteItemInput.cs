using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Application.UseCases.DeleteItem
{
	public class DeleteItemInput : IRequest<Output<bool>>
	{
		public Guid Id { get; set; }
	}
}
