using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Domain.Entities;
using TibiaItem.Domain.Interface;

namespace TibiaItem.Application.Handlers
{
	internal class CreateItemHandler : IRequestHandler<CreateItemRequest, Object>

	{

		private readonly IItemRepository _itemRepository;
		private readonly IMapper _mapper;

		public CreateItemHandler(IItemRepository repository, IMapper mapper)
		{
			_itemRepository = repository;
			_mapper = mapper;
		}

		public async Task<Object> Handle(CreateItemRequest request, CancellationToken cancellationToken)
		{
			var item = _mapper.Map<Item>(request);
			item.NewItem();
			await _itemRepository.CreateNewItem(item, cancellationToken);
			return true;
        }
	}
}
