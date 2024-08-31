using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaItem.Domain.Entities
{
	public class Item
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public string Type { get; private set; }

		public SlotsInfo Slots { get; private set; }

		public decimal Price { get; private set; }

		public DateTime Date { get; private set; }

		public Item(string name, string type, SlotsInfo slots, decimal price)
		{
			Name = name;
			Type = type;
			Slots = slots;
			Price = price;

		}

		public void NewItem()
		{
			Id = Guid.NewGuid();
			Date = DateTime.Now;
		}
	}


	public class SlotsInfo
	{
		public bool HaveSlots { get; set; }
		public int Quantity { get; set; }
	}
}
