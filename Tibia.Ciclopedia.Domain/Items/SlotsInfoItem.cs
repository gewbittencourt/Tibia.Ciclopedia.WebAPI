using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Domain.ValueObjects
{
	public class SlotsInfoItem
	{
		public bool HaveSlots { get; private set; }
		public int Quantity { get; private set; }

		public SlotsInfoItem(bool haveSlots, int quantity)
		{
			HaveSlots = haveSlots;
			Quantity = quantity;
		}
	}


}
