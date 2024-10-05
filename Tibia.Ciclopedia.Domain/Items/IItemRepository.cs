using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Domain.Items
{
	public interface IItemRepository
	{
		Task CreateNewItem(Item item, CancellationToken cancellationToken);

		Task<IEnumerable<Item>> GetAllItems(CancellationToken cancellationToken);

		Task<Item> GetItemsByName(String name, CancellationToken cancellationToken);

		Task<Item> GetItemById(Guid id, CancellationToken cancellationToken);

		Task<bool> UpdateItem(Item item, CancellationToken cancellationToken);

		Task<bool> Deletetem(Item item, CancellationToken cancellationToken);
	}
}