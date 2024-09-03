using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAll;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem
{
	public class UpdateAllItem : IUpdateAllItemUseCase
	{

		private readonly IItemRepository _itemRepository;


		public UpdateAllItem(IItemRepository repository, IMapper mapper)
		{
			_itemRepository = repository;
		}


		public async Task<Output<bool>> Handle(UpdateAllItemCommand request, CancellationToken cancellationToken)
		{
			var item = await _itemRepository.GetByIdItems(request.Id, cancellationToken);
			item.UpdateAllItem(request.Input.Name, request.Input.Type.ToString(), request.Input.Vocations.ToString(), request.Input.Slots, request.Input.Image);
			item.UpdatePriceItem(request.Input.Price);

			var result = await _itemRepository.UpdateAllItem(item, cancellationToken);
			return Output<bool>.Success(result);


		}
	}
}
