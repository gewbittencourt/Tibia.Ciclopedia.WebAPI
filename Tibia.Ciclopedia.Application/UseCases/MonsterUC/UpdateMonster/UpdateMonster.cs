using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.UpdateMonster
{
	public class UpdateMonster : IUpdateMonsterUseCase
	{

		private readonly IMonsterRepository _monsterRepository;

		public UpdateMonster(IMonsterRepository monsterRepository)
		{
			_monsterRepository = monsterRepository;
		}

		public async Task<Output<bool>> Handle(UpdateMonsterInput request, CancellationToken cancellationToken)
		{
			try
			{
				var monster = await _monsterRepository.GetMonsterById(request.Id, cancellationToken);
				if (monster == null)
				{
					return Output<bool>.Failure(new List<string> { "Não foi possível encontrar o monstro especificado." });
				}

				monster.UpdateMonster(request.Name, request.HitPoints, request.Experience, request.DifficultyCategory);
				var result = await _monsterRepository.UpdateMonster(monster, cancellationToken);

				return Output<bool>.Success(result);
			}
			catch (Exception ex)
			{
				return Output<bool>.Failure(new List<string> { $"Não foi possível atualizar o monstro especificado.{ex.Message}" });
			}

		}
	}
}
