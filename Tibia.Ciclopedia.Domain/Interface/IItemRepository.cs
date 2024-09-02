using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Entities;

namespace Tibia.Ciclopedia.Domain.Interface
{
	public interface IItemRepository
	{
		Task CreateNewItem(Item item, CancellationToken cancellationToken);
	}
}