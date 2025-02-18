using System.Diagnostics;
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

		public double SellingPrice { get; private set; }

		public double PurchasePrice { get; private set; }

		public PeriodControl Period { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; private set; }

		public string Image { get; private set; }



		public Item(string name, ItemType type, Vocations vocations, SlotsInfoItem slots, double purchaseprice, double sellingprice, string image, int levelRequired)
		{
			Name = name;
			Type = type;
			Vocations = vocations;
			Slots = slots;
			SellingPrice = sellingprice;
			PurchasePrice = purchaseprice;
			Image = image;
			LevelRequired = levelRequired;
		}

		public Item()
		{
		}

		public Item(string name)
		{
			Name = name;
		}

		public bool CheckPeriod()
		{
			if (Period == null || Period.TimeCheckedExpire < DateTime.UtcNow)
			{
				return true;
			}
			return false;
		}

		public void NewItem()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
			Slug = Name.ToLowerInvariant().Replace(" ", "");
		}

		public void UpdatePriceItem(double price)
		{
			Period = new PeriodControl();
			SellingPrice = price;
			PurchasePrice = price;
		}

		public void UpdateItem(string? name, ItemType? type, Vocations? vocations, SlotsInfoItem? slots, string image, int? levelRequired, PeriodControl? periodControl, double? sellingPrice, double? purchasePrice)
		{
			if (!string.IsNullOrEmpty(name))
			{
				Name = name;
				Slug = name.ToLowerInvariant().Replace(" ", "");
			}
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

			if (sellingPrice.HasValue)
				SellingPrice = sellingPrice.Value;

			if (purchasePrice.HasValue)
				PurchasePrice = purchasePrice.Value;


			UpdatedAt = DateTime.UtcNow;
		}
	}
}