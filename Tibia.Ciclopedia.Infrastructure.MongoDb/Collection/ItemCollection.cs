using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Items.Enums;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members;
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

		[BsonElement("Slug")]
		public string Slug { get; set; }

		[BsonElement("ItemType")]
		public ItemType Type { get; set; }

		[BsonElement("Vocations")]
		public Vocations Vocations { get; set; }

		[BsonElement("LevelRequired")]
		public int LevelRequired { get; set; }

		[BsonElement("PeriodControl")]
		public PeriodControlCollectionMember Period { get; set; }

		[BsonElement("ItemSlots")]
		public SlotsInfoItemCollectionMember Slots { get; set; }

		[BsonElement("ItemPrice")]
		public double Price { get; set; }

		[BsonElement("CreationDate")]
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime CreatedAt { get; set; }

		[BsonElement("UpdatedDate")]
		[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
		public DateTime UpdatedAt { get; set; }

		[BsonElement("ImageLink")]
		public string Image { get; set; }

	}


}
