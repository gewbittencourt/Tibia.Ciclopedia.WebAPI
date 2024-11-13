using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Tests.CrossCuttingTests.GetResponseTests
{
	public class GetPricingResponseRateFloatTests
	{
		[Fact]
		public void GetPricingResponseRateFloat_ShouldDeserializeCorrectly()
		{
			// Arrange: JSON example to simulate API response
			var json = @"{
                ""rate_float"": 1.2345
            }";

			// Act: Deserialize JSON to GetPricingResponseRateFloat object
			var result = JsonSerializer.Deserialize<GetPricingResponseRateFloat>(json);

			// Assert: Check if the deserialization was successful and the value is correct
			Assert.NotNull(result);
			Assert.Equal(1.2345, result.Ratefloat);
		}
	}
}
