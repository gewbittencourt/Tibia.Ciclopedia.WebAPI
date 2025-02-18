using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.MonsterMember;

namespace Tibia.Ciclopedia.Tests.MonsterTests.CollectionTest.MonsterMemberTest
{
	public class MonsterDifficultyCollectionMemberTests
	{
		[Fact]
		public void MonsterDifficultyCollectionMember_Should_HaveCorrectValueForHard()
		{
			// Arrange
			var difficulty = MonsterDifficultyCollectionMember.Hard;

			// Act
			var actualValue = (int)difficulty;

			// Assert
			Assert.Equal(4, actualValue);
		}
	}
}
