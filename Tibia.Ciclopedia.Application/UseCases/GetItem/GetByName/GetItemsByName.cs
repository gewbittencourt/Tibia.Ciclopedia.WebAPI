using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName
{
	public class GetByNameItems : IGetItemsByNameUseCase
	{
		private readonly IItemRepository _itemRepository;

		public GetByNameItems(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public async Task<Output<IEnumerable<Item>>> Handle(GetByNameItemsInput request, CancellationToken cancellationToken)
		{
			var result = await _itemRepository.GetItemsByName(request.Name, cancellationToken);
			return Output<IEnumerable<Item>>.Success(result);
		}
	}
}
