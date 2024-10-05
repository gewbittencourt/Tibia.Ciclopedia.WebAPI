using Tibia.Ciclopedia.Domain.Items.Enums;

namespace Tibia.Ciclopedia.Domain.Items
{
	public class Item
	{
		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public string Slug { get; private set; }

		public ItemType Type { get; private set; }

		public Vocations Vocations { get; private set; }

		public SlotsInfoItem Slots { get; private set; }

		public int LevelRequired { get; private set; }

		public double Price { get; private set; }

		public PeriodControl Period { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; private set; }

		public string Image { get; private set; }



		public Item(string name, ItemType type, Vocations vocations, SlotsInfoItem slots, double price, string image, int levelRequired)
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
			CreatedAt = DateTime.UtcNow;
			Slug = Name.ToLowerInvariant().Replace(" ","");
		}

		public void UpdatePriceItem()
		{
			Period = new PeriodControl();
			Price = Price+1;
		}

		public void UpdateItem(string name, ItemType? type, Vocations? vocations, SlotsInfoItem slots, string image, int? levelRequired, double? price, PeriodControl periodControl)
		{
			if (!string.IsNullOrEmpty(name))
				Name = name;
				Slug = name.ToLowerInvariant().Replace(" ","");

			if (type.HasValue)
				Type = (ItemType)type;

			if (vocations.HasValue)
				Vocations = (Vocations)vocations;


			if (slots != null)
				Slots = slots;

			if (periodControl != null)
				Period = periodControl;

			if (!string.IsNullOrEmpty(image))
				Image = image;

			if (levelRequired.HasValue)
				LevelRequired = levelRequired.Value;

			if (price.HasValue)
				Price = price.Value;

			UpdatedAt = DateTime.UtcNow;
		}
	}
}