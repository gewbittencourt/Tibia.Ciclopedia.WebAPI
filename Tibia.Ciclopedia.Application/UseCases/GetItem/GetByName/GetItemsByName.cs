using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Infrastructure.CrossCutting;

namespace Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName
{
	public class GetByNameItems : IGetItemsByNameUseCase
	{
		private readonly IItemRepository _itemRepository;

		private readonly CrossCutting _crossCutting;

		public GetByNameItems(IItemRepository itemRepository)
		{
			_crossCutting = new CrossCutting();
			_itemRepository = itemRepository;
		}

		public async Task<Output<Item>> Handle(GetByNameItemsInput request, CancellationToken cancellationToken)
		{
			var result = await _itemRepository.GetItemsByName(request.Name.ToLowerInvariant().Replace(" ",""), cancellationToken);
			if (result.Period == null || result.Period.TimeCheckedExpire < DateTime.UtcNow)
			{
				var price = await _crossCutting.GetPriceAsync();
				result.UpdatePriceItem(price);
				await _itemRepository.UpdateItem(result, cancellationToken);
			}
			return Output<Item>.Success(result);
		}
	}
}
