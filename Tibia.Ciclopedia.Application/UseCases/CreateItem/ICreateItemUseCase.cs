using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Application.UseCases.CreateItem
{
    public interface ICreateItemUseCase : IRequestHandler<CreateItemInput, Output<bool>>
	{
	}
}
