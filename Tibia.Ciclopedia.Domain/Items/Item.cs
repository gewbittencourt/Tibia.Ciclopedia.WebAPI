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

		public SlotsInfoItem Slots { get; private set; }

		public int LevelRequired { get; private set; }

		public double Price { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; private set; }

		public string Image { get; private set; }



		public Item(string name, string type, string vocations, SlotsInfoItem slots, double price, string image, int levelRequired)
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
			CreatedAt = DateTime.Now;
		}

		public void UpdatePriceItem(Double price)
		{
			UpdatedAt = DateTime.Now;
			Price = price;
		}

		public void UpdateItem(string name, string type, string vocations, SlotsInfoItem slots, string image, int? levelRequired, double? price)
		{
			if (!string.IsNullOrEmpty(name))
				Name = name;

			if (!string.IsNullOrEmpty(type))
				Type = type;

			if (!string.IsNullOrEmpty(vocations))
				Vocations = vocations;

			if (slots != null)
				Slots = slots;

			if (!string.IsNullOrEmpty(image))
				Image = image;

			if (levelRequired.HasValue)
				LevelRequired = levelRequired.Value;

			if (price.HasValue)
				Price = price.Value;

			UpdatedAt = DateTime.Now;
		}
	}
}