using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Domain.Items
{
	public class PeriodControl
	{
		public DateTime TimeChecked { get; private set; }
		public DateTime TimeCheckedExpire { get; private set; }


		public PeriodControl()
		{
			TimeChecked = DateTime.UtcNow;
			TimeCheckedExpire = DateTime.UtcNow.AddSeconds(5);
		}
	}


}
