using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Domain.Interface;

namespace TibiaItem.Application.Handlers
{
	internal class CreateItemHandler : IRequestHandler<CreateItemRequest, Object>

	{

		private readonly IItemRepository _repository;

		public CreateItemHandler(IItemRepository repository)
		{
			_repository = repository;
		}

		public async Task<Object> Handle(CreateItemRequest request, CancellationToken cancellationToken)
		{
			var teste = request;
            return teste;
        }
	}
}
