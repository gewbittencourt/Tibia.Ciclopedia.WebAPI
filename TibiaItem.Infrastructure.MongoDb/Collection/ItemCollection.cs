using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TibiaItem.Infrastructure.MongoDb.Collection
{
	public class ItemCollection
	{
		public const string CollectionName = "ItemCollection";


		[BsonId]
		[BsonIgnoreIfDefault]
		public ObjectId Id { get; set; }

		[BsonElement("ItemId")]
		public Guid ItemID { get; set; }

		[BsonElement("ItemName")]
		public string Name { get; private set; }

		[BsonElement("ItemType")]
		public string Type { get; private set; }

		[BsonElement("ItemSlots")]
		public SlotsInfo Slots { get; private set; }

		[BsonElement("ItemPrice")]
		public decimal Price { get; private set; }

		[BsonElement("CreationDate")]
		public DateTime Date { get; private set; }


		public class SlotsInfo
		{
			public bool HaveSlots { get; set; }
			public int Quantity { get; set; }
		}
	}
}
