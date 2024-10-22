using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll
{
	public class GetAllMonsters : IGetAllMonstersUseCase
	{

		private readonly IMonsterRepository _monsterRepository;

		public GetAllMonsters(IMonsterRepository monsterRepository)
		{
			_monsterRepository = monsterRepository;
		}

		public async Task<Output<IEnumerable<Monster>>> Handle(GetAllMonsterInput request, CancellationToken cancellationToken)
		{
			var monsterListResult = await _monsterRepository.GetAllMonsters(cancellationToken);
			return Output<IEnumerable<Monster>>.Success(monsterListResult);
		}
	}
}
