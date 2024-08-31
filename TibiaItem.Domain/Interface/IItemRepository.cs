using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Domain.Entities;

namespace TibiaItem.Domain.Interface
{
	public interface IItemRepository
	{
		Task CreateNewTask(Item item, CancellationToken cancellationToken);
	}
}
