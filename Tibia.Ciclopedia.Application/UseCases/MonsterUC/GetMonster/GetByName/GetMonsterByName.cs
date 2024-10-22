using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName
{
	public class GetMonsterByName : IGetMonsterByNameUseCase
	{

		private readonly IMonsterRepository _monsterRepository;

		public GetMonsterByName(IMonsterRepository monsterRepository)
		{
			_monsterRepository = monsterRepository;
		}

		public async Task<Output<Monster>> Handle(GetMonsterByNameInput request, CancellationToken cancellationToken)
		{
			var monsterReturn = await _monsterRepository.GetMonsterByName(request.Name, cancellationToken);
			if (monsterReturn == null)
			{
				return Output<Monster>.Failure(new List<string> { "Monstro não encontrado" });
			}
			return Output<Monster>.Success(monsterReturn);
		}
	}
}
