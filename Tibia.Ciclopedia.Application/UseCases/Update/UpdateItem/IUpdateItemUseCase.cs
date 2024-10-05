using MediatR;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Application.UseCases.Update.UpdateItem
{
	public interface IUpdateItemUseCase : IRequestHandler<UpdateItemInput, Output<bool>>
	{
	}
}
