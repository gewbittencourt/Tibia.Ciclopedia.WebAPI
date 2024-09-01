using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Application.BaseOutput;
using TibiaItem.Domain.Entities;
using TibiaItem.Domain.Interface;

namespace TibiaItem.Application.UseCases.CreateItem
{
	internal class CreateItem : IRequestHandler<CreateItemInput, Output<bool>>

	{

		private readonly IItemRepository _itemRepository;
		private readonly IMapper _mapper;

		public CreateItem(IItemRepository repository, IMapper mapper)
		{
			_itemRepository = repository;
			_mapper = mapper;
		}

		public async Task<Output<bool>> Handle(CreateItemInput request, CancellationToken cancellationToken)
		{
			var item = _mapper.Map<Item>(request);
			item.NewItem();
			await _itemRepository.CreateNewItem(item, cancellationToken);
			return Output<bool>.Success(true);
		}
	}
}
