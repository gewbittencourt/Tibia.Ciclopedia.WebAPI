using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection
{
	public class ItemCollection
	{
		public const string CollectionName = "ItemCollection";


		[BsonId]
		[BsonIgnoreIfDefault]
		public ObjectId Id { get; private set; }

		[BsonElement("ItemId")]
		public Guid ItemID { get; private set; }

		[BsonElement("ItemName")]
		public string Name { get; private set; }

		[BsonElement("ItemType")]
		public string Type { get; private set; }

		[BsonElement("Vocations")]
		public string Vocations { get; private set; }

		[BsonElement("ItemSlots")]
		public SlotsInfo Slots { get; private set; }

		[BsonElement("ItemPrice")]
		public double Price { get; private set; }

		[BsonElement("CreationDate")]
		public DateTime Date { get; private set; }

		[BsonElement("ImageLink")]
		public string Image { get; private set; }
	}
}
