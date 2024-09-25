using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem
{
	public class UpdateItem : IUpdateItemUseCase
	{

		private readonly IItemRepository _itemRepository;


		public UpdateItem(IItemRepository repository, IMapper mapper)
		{
			_itemRepository = repository;
		}


		public async Task<Output<bool>> Handle(UpdateItemInput request, CancellationToken cancellationToken)
		{
			var item = await _itemRepository.GetByIdItems(request.id, cancellationToken);
			item.UpdateItem(request.Name, request.Type.ToString(), request.Vocations.ToString(), request.Slots, request.Image, request.LevelRequired, request.Price);

			var result = await _itemRepository.UpdateItem(item, cancellationToken);
			return Output<bool>.Success(result);


		}
	}
}
