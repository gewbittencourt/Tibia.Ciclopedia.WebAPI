using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster
{
	public class DeleteMonster : IDeleteMonsterUseCase
	{
		private readonly IMonsterRepository _monsterRepository;

		public DeleteMonster(IMonsterRepository monsterRepository)
		{
			_monsterRepository = monsterRepository;
		}

		public async Task<Output<bool>> Handle(DeleteMonsterInput request, CancellationToken cancellationToken)
		{
			var deleteReturn = await _monsterRepository.DeleteMonster(request.id, cancellationToken);
			if(!deleteReturn)
			{
				return Output<bool>.Failure(new List<string> { "Não foi possível deleter o monstro." });
			}
			return Output<bool>.Success(deleteReturn);
		}
	}
}
