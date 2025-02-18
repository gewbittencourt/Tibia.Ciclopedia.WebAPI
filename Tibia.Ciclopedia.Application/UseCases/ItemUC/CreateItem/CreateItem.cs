using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem
{
    public class CreateItem : ICreateItemUseCase

    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateItem(IItemRepository repository, IMapper mapper)
        {
            _itemRepository = repository;
            _mapper = mapper;
        }

        public async Task<Output<Guid>> Handle(CreateItemInput request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _mapper.Map<Item>(request);
                item.NewItem();
                await _itemRepository.CreateNewItem(item, cancellationToken);
                return Output<Guid>.Success(item.Id);
            }
            catch (Exception ex)
            {
                return Output<Guid>.Failure(new List<string> { $"Não foi possível cadastrar o item.{ex.Message}" });
            }

        }
    }
}
