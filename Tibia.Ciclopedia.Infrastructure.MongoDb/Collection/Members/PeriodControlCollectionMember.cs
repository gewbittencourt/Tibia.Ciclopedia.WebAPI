using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members
{
	public class PeriodControlCollectionMember
	{
		public DateTime TimeChecked { get; set; }
		public DateTime TimeCheckedExpire { get; set; }
	}
}
