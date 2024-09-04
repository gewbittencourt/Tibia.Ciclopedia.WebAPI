using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application.UseCases.DeleteItem
{
	public class DeleteItem : IDeleteItemUseCase
	{
		private readonly IItemRepository _itemRepository;

		public DeleteItem(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public async Task<Output<bool>> Handle(DeleteItemInput request, CancellationToken cancellationToken)
		{
			var item = await _itemRepository.GetByIdItems(request.Id, cancellationToken);
			var result = await _itemRepository.Deletetem(item, cancellationToken);
			return Output<bool>.Success(result);
		}
	}
}
