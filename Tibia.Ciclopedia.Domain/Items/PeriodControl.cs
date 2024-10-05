using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Domain.Items
{
	public class PeriodControl
	{
		public DateTime TimeCheck { get; private set; }
		public DateTime TimeCheckExpire { get; private set; }


		public PeriodControl()
		{
			TimeCheck = DateTime.Now;
			TimeCheckExpire = DateTime.Now.AddSeconds(5);
		}
	}


}
