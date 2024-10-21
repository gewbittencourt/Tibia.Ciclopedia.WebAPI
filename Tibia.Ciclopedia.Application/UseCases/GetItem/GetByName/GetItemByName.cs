using MediatR;
using Polly;
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
	public class GetItemsByName : IGetItemByNameUseCase
	{
		private readonly IItemRepository _itemRepository;

		private readonly IMarketService _marketService;

		public GetItemsByName(IItemRepository itemRepository, IMarketService marketService)
		{
			_marketService = marketService;
			_itemRepository = itemRepository;
		}

		public async Task<Output<Item>> Handle(GetItemByNameInput request, CancellationToken cancellationToken)
		{
			var itemResult = await _itemRepository.GetItemByName(request.Name.ToLowerInvariant().Replace(" ", ""), cancellationToken);
			if (itemResult == null)
			{
				return Output<Item>.Failure(new List<string> { "Item não encontrado" });
			}

			var priceUpdateResult = await UpdateItemPriceIfNecessary(itemResult, cancellationToken);
			if (!priceUpdateResult.IsValid)
			{
				return priceUpdateResult;
			}

			return Output<Item>.Success(itemResult);
		}




		private async Task<Output<Item>> UpdateItemPriceIfNecessary(Item itemResult, CancellationToken cancellationToken)
		{
			if (itemResult.CheckPeriod())
			{
				try
				{
					var priceReturn = await _marketService.GetPriceAsync(cancellationToken);
					if (priceReturn.Price > 0)
					{
						itemResult.UpdatePriceItem(priceReturn.Price);
						await _itemRepository.UpdateItem(itemResult, cancellationToken);
					}
				}
				catch (Exception)
				{
					return Output<Item>.Failure(new List<string> { "Erro ao obter o preço." });
				}
			}

			return Output<Item>.Success(itemResult);
		}



	}
}
