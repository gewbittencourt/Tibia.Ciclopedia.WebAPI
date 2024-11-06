using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Monsters.Enums;

namespace Tibia.Ciclopedia.Domain.Monsters
{
	public interface IMonsterRepository
	{
		Task CreateNewMonster(Monster monster, CancellationToken cancellationToken);

		Task<IEnumerable<Monster>> GetAllMonsters(CancellationToken cancellationToken);

		Task<Monster> GetMonsterByName(string name, CancellationToken cancellationToken);

		Task<IEnumerable<Monster>> GetMonsterByElementAndDifficulty(string name, MonsterDifficulty difficulty, CancellationToken cancellationToken);

		Task<Monster> GetMonsterById(Guid id, CancellationToken cancellationToken);

		Task<bool> UpdateMonster(Monster monster, CancellationToken cancellationToken);

		Task<bool> DeleteMonster(Guid id, CancellationToken cancellationToken);

	}
}
