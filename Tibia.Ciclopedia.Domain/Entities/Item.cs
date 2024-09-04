using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.ValueObjects;

namespace Tibia.Ciclopedia.Domain.Entities
{
	public class Item
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public string Type { get; private set; }

		public string Vocations { get; private set; }

		public SlotsInfo Slots { get; private set; }

		public int LevelRequired { get; private set; }

		public double Price { get; private set; }

		public DateTime Date { get; private set; }

		public string Image { get; private set; }



		public Item(string name, string type, string vocations, SlotsInfo slots, double price, string image, int levelRequired)
		{
			Name = name;
			Type = type;
			Vocations = vocations;
			Slots = slots;
			Price = price;
			Image = image;
			LevelRequired = levelRequired;
		}

		public Item()
		{
		}

		public void NewItem()
		{
			Id = Guid.NewGuid();
			Date = DateTime.Now;
		}

		public void UpdatePriceItem(Double price)
		{
			Date = DateTime.Now;
			Price = price;
		}

		public void UpdateAllItem(string name, string type, string vocations, SlotsInfo slots, string image, int levelRequired)
		{
			Name = name;
			Type = type;
			Vocations = vocations;
			Slots = slots;
			Image = image;
			LevelRequired = levelRequired;
		}
	}
}