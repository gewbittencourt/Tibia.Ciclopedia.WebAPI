using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember
{
	public class ElementsWeaknessMonsterCollectionMember
	{
		public int Physical { get;  set; }
		public int Earth { get;  set; }
		public int Fire { get;  set; }
		public int Death { get;  set; }
		public int Ice { get;  set; }
		public int Energy { get;  set; }
		public int Holy { get;  set; }
	}
}
