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
	public class GetByNameItems : IGetItemsByNameUseCase
	{
		private readonly IItemRepository _itemRepository;

		private readonly ICrossCutting _crossCutting;

		public GetByNameItems(IItemRepository itemRepository, ICrossCutting crossCutting)
		{
			_crossCutting = crossCutting;
			_itemRepository = itemRepository;
		}

		public async Task<Output<Item>> Handle(GetByNameItemsInput request, CancellationToken cancellationToken)
		{
			var result = await _itemRepository.GetItemsByName(request.Name.ToLowerInvariant().Replace(" ", ""), cancellationToken);
			if (result != null)
			{
				if (result.Period == null || result.Period.TimeCheckedExpire < DateTime.UtcNow)
				{
					try
					{
						double price = await _crossCutting.GetPriceAsync();
						result.UpdatePriceItem(price);
						await _itemRepository.UpdateItem(result, cancellationToken);
					}
					catch (Exception ex)
					{
						return Output<Item>.Failure(new List<string> { "Erro ao obter o preço." });
					}
				}

				return Output<Item>.Success(result);
			}
			return Output<Item>.Failure(new List<string> { "Item não encontrado"});
		}
	}
}
