using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Tests.CrossCuttingTests.GetResponseTests
{
	public class GetPriceResponseEURTests
	{
		[Fact]
		public void GetPriceResponseEUR_ShouldDeserializeCorrectly()
		{
			// Arrange: JSON example to simulate API response
			var json = @"{
                ""EUR"": {
                    ""rate_float"": 1.2345
                }
            }";

			// Act: Deserialize JSON to GetPriceResponseEUR object
			var result = JsonSerializer.Deserialize<GetPriceResponseEUR>(json);

			// Assert: Check if the deserialization was successful
			Assert.NotNull(result);
			Assert.NotNull(result.EUR);
			Assert.Equal(1.2345d, result.EUR.Ratefloat);
		}
	}
}