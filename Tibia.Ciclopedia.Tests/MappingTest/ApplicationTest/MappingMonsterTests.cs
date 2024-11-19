using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Domain.Monsters.Enums;
using Tibia.Ciclopedia.Domain.Monsters;
using Tibia.Ciclopedia.Application.Mapping;

namespace Tibia.Ciclopedia.Tests.MappingTest.ApplicationTest
{
	public class MappingMonsterTests
	{
		private readonly IMapper _mapper;

		public MappingMonsterTests()
		{
			var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingMonster>());
			_mapper = config.CreateMapper();
		}

		[Fact]
		public void Mapping_CreateMonsterInput_To_Monster_MapsCorrectly()
		{
			// Arrange
			var input = new CreateMonsterInput
			{
				Name = "Dragon",
				HitPoints = 5000,
				Experience = 1000,
				DifficultyCategory = MonsterDifficulty.Hard,
				ElementsWeaknessMonster = new ElementsWeaknessMonster(50, 40, 30, 20, 10, 60, 70)
			};

			// Act
			var result = _mapper.Map<Monster>(input);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(input.Name, result.Name);
			Assert.Equal(input.HitPoints, result.HitPoints);
			Assert.Equal(input.Experience, result.Experience);
			Assert.Equal(input.DifficultyCategory, result.DifficultyCategory);
			Assert.Equal(input.ElementsWeaknessMonster.Fire, result.ElementsWeaknessMonster.Fire);
			Assert.Equal(input.ElementsWeaknessMonster.Earth, result.ElementsWeaknessMonster.Earth);
			Assert.NotEqual(Guid.Empty, result.Id);
		}
	}
}
