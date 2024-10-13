using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.DTO;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
	public interface IMarketService
	{
		public Task<ItemMarketPrice> GetPriceAsync(CancellationToken cancellationToken);
	}
}
