using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;

namespace Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll
{
    public class GetAllItem : IGetAllItemUseCase
    {

        private readonly IItemRepository _itemRepository;

        public GetAllItem(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Output<IEnumerable<Item>>> Handle(GetAllItemInput request, CancellationToken cancellationToken)
        {
            var result = await _itemRepository.GetAllItems(cancellationToken);
            return Output<IEnumerable<Item>>.Success(result);
        }
    }
}
