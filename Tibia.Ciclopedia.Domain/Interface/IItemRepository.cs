﻿using Tibia.Ciclopedia.Domain.Entities;

namespace Tibia.Ciclopedia.Domain.Interface
{
	public interface IItemRepository
	{
		Task CreateNewItem(Item item, CancellationToken cancellationToken);

		Task<IEnumerable<Item>> GetAllItems(CancellationToken cancellationToken);

		Task<IEnumerable<Item>> GetByNameItems(String name, CancellationToken cancellationToken);
	}
}