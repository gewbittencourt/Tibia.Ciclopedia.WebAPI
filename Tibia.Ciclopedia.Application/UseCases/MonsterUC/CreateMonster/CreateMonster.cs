using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;
using Tibia.Ciclopedia.Domain.Monsters;

namespace Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster
{
	public class CreateMonster : ICreateMonsterUseCase
	{
		private readonly IMonsterRepository _mosterRepository;
		private readonly IMapper _mapper;

		public CreateMonster(IMonsterRepository mosterRepository, IMapper mapper)
		{
			_mosterRepository = mosterRepository;
			_mapper = mapper;
		}

		public async Task<Output<Guid>> Handle(CreateMonsterInput request, CancellationToken cancellationToken)
		{
			var monster = _mapper.Map<Monster>(request);
			await _mosterRepository.CreateNewMonster(monster, cancellationToken);
			return Output<Guid>.Success(monster.Id);
		}
	}
}
