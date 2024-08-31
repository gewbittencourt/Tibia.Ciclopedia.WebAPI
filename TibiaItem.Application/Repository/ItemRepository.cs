using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaItem.Domain.Entities;
using TibiaItem.Domain.Interface;

namespace TibiaItem.Application.Repository
{
	public class ItemRepository : IItemRepository
	{
		public Task CreateNewTask(Item item, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
