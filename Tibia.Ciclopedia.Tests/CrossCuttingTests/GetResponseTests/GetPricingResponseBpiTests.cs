using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Tests.CrossCuttingTests.GetResponseTests
{
	public class GetPricingResponseBpiTests
	{
		[Fact]
		public void GetPricingResponseBpi_ShouldDeserializeCorrectly()
		{
			// Arrange
			var json = @"{
                ""bpi"": {
                    ""EUR"": {
                        ""rate_float"": 1.2345
                    }
                }
            }";

			// Act
			var result = JsonSerializer.Deserialize<GetPricingResponseBpi>(json);

			// Assert
			Assert.NotNull(result);
			Assert.NotNull(result.Bpi);
			Assert.NotNull(result.Bpi.EUR);

			// Assert
			Assert.Equal(1.2345d, result.Bpi.EUR.Ratefloat);
		}
	}
}
