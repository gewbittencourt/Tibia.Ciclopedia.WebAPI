using MediatR;
using TibiaItem.Application.BaseOutput;

namespace TibiaItem.Application.UseCases.CreateItem
{
	public class CreateItemInput : IRequest<Output<bool>>
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public SlotsInfo Slots { get; set; }

		public double Price { get; set; }
	}


	public class SlotsInfo
	{
		public bool HaveSlots { get; set; }
		public int Quantity { get; set; }
	}
}
