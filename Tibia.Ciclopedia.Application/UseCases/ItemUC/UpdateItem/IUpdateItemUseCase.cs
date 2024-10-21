using MediatR;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Application.UseCases.ItemUC.UpdateItem
{
    public interface IUpdateItemUseCase : IRequestHandler<UpdateItemInput, Output<bool>>
    {
    }
}
