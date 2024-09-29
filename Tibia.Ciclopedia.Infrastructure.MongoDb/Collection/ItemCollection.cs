using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection
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
		public string Name { get; set; }

		[BsonElement("ItemType")]
		public ItemType Type { get; set; }

		[BsonElement("Vocations")]
		public Vocations Vocations { get; set; }

		[BsonElement("LevelRequired")]
		public int LevelRequired { get; set; }

		[BsonElement("ItemSlots")]
		public SlotsInfoItem Slots { get; set; }

		[BsonElement("ItemPrice")]
		public double Price { get; set; }

		[BsonElement("CreationDate")]
		public DateTime CreatedAt { get; set; }

		[BsonElement("UpdatedDate")]
		public DateTime UpdatedAt { get; set; }

		[BsonElement("ImageLink")]
		public string Image { get; set; }

	}


}
