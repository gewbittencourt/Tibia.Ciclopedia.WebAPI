using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.MongoDb.Collection.Members.ItemMember;

namespace Tibia.Ciclopedia.Tests.ItemTests.CollectionTest.ItemMemberTest
{
	public class PeriodControlCollectionMemberTests
	{
		[Fact]
		public void PeriodControlCollectionMember_Should_SetAndRetrieveProperties()
		{
			// Arrange
			var timeChecked = DateTime.Now;
			var timeCheckedExpire = DateTime.Now.AddHours(1);

			var periodControl = new PeriodControlCollectionMember
			{
				TimeChecked = timeChecked,
				TimeCheckedExpire = timeCheckedExpire
			};

			// Act & Assert
			Assert.Equal(timeChecked, periodControl.TimeChecked);
			Assert.Equal(timeCheckedExpire, periodControl.TimeCheckedExpire);
		}
	}
}