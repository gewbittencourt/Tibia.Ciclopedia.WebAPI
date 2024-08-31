using MediatR;

namespace TibiaItem.Application.Handlers
{
	public class CreateItemRequest : IRequest<Object>
	{
		public string Name { get; set; }

		public string Type { get; set; }

		public SlotsInfo Slots { get; set; }

		public decimal Price { get; set; }
	}


	public class SlotsInfo
	{
		public bool PossuiSlots { get; set; }
		public int Quantidade { get; set; }
	}
}
