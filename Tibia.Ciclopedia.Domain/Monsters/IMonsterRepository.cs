using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Domain.Monsters
{
	public interface IMonsterRepository
	{
		Task CreateNewMonster(Monster monster, CancellationToken cancellationToken);
	}
}
