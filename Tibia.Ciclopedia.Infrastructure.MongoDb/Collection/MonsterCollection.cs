using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection
{
	public class MonsterCollection
	{
		public const string CollectionName = "MonsterCollection";


		[BsonId]
		[BsonIgnoreIfDefault]
		public ObjectId Id { get; set; }

		[BsonElement("MonsterId")]
		public Guid MonsterId { get; private set; }

		[BsonElement("MonsterName")]
		public string Name { get; private set; }

		[BsonElement("MonsterHitPoints")]
		public int HitPoints { get; private set; }

		[BsonElement("MonsterExperience")]
		public int Experience { get; private set; }

		[BsonElement("MonsterCategory")]
		public MonsterDifficultyCollectionMember DifficultyCategory { get; set; }

		[BsonElement("ElementWeakness")]
		public ElementsWeaknessMonsterCollectionMember ElementsWeaknessMonster { get; set; }
	}
}
