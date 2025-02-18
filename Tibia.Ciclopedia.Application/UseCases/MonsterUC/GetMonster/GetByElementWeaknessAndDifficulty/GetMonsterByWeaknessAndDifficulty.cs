using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty
{
	public class GetMonsterByWeaknessAndDifficulty : IGetMonsterByWeaknessAndDifficultyUseCase
	{
		private readonly IMonsterRepository _monsterRepository;

		public GetMonsterByWeaknessAndDifficulty(IMonsterRepository monsterRepository)
		{
			_monsterRepository = monsterRepository;
		}

		public async Task<Output<IEnumerable<Monster>>> Handle(GetMonsterByWeaknessAndDifficultyInput request, CancellationToken cancellationToken)
		{
			string element = char.ToUpper(request.Element[0]) + request.Element.Substring(1);
			var monsterReturn = await _monsterRepository.GetMonsterByElementAndDifficulty(element, request.DifficultyCategory, cancellationToken);
			return Output<IEnumerable<Monster>>.Success(monsterReturn);
		}
	}
}
