using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
	public interface ICrossCutting
	{
		public Task<double> GetPriceAsync();
	}
}
