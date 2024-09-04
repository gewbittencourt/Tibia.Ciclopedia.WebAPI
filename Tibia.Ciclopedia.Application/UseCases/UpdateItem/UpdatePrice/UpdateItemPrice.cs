using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdatePrice;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice
{
	public class UpdateItemPrice : IUpdateItemPriceUseCase
	{

		private readonly IItemRepository _itemRepository;

		public UpdateItemPrice(IItemRepository repository, IMapper mapper)
		{
			_itemRepository = repository;
		}
		public async Task<Output<bool>> Handle(UpdateItemPriceCommand request, CancellationToken cancellationToken)
		{
			var item = await _itemRepository.GetByIdItems(request.Id, cancellationToken);
			item.UpdatePriceItem(request.Input.Price);
			var result = await _itemRepository.UpdateItemPrice(item, cancellationToken);
			return Output<bool>.Success(result);
		}
	}
}
