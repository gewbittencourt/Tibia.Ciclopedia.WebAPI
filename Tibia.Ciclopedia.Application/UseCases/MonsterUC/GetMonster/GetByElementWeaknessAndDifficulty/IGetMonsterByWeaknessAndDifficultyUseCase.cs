using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByElementWeaknessAndDifficulty
{
	public interface IGetMonsterByWeaknessAndDifficultyUseCase : IRequestHandler<GetMonsterByWeaknessAndDifficultyInput, Output<IEnumerable<Monster>>>
	{
	}
}
