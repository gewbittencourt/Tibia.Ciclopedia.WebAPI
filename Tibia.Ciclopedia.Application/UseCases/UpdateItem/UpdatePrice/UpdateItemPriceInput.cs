using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateItemPrice
{
    public class UpdateItemPriceInput : IRequest<Output<bool>>
    {
        public double Price { get; set; }
    }
}
