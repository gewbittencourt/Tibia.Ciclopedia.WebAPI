using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using Tibia.Ciclopedia.Domain.ValueObjects;

namespace Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem
{
	public class UpdateAllItemInput : IRequest<Output<bool>>
	{
		public string Name { get; set; }
		public ItemType Type { get; set; }
		public Vocations Vocations { get; set; }
		public int LevelRequired { get; set; }
		public SlotsInfo Slots { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }

	}
}
