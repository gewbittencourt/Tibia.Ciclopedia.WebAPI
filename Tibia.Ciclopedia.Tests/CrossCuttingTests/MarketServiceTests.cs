using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Domain.Items.DTO;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;
using Tibia.Ciclopedia.Infrastructure.CrossCutting;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Moq.Protected;

namespace Tibia.Ciclopedia.Tests.CrossCuttingTests
{
	public class MarketServiceTests
	{
		[Fact]
		public async Task GetPriceAsync_ShouldReturnMappedItemMarketPrice_WhenApiResponseIsSuccessful()
		{
			// Arrange
			var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

			var mockConfiguration = new Mock<IConfiguration>();
			mockConfiguration.Setup(config => config["GetPriceAPI:Url"]).Returns("http://testapi.com");

			var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object)
			{
				BaseAddress = new Uri("http://testapi.com")
			};

			var mockMapper = new Mock<IMapper>();

			var mockPricingResponse = new GetPricingResponseBpi { /* Inicialize as propriedades conforme necessário */ };
			var expectedMarketPrice = new ItemMarketPrice { /* Inicialize as propriedades conforme necessário */ };

			var jsonResponse = JsonSerializer.Serialize(mockPricingResponse);

			mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>()
				)
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(jsonResponse)
				});

			mockMapper
				.Setup(mapper => mapper.Map<ItemMarketPrice>(It.IsAny<GetPricingResponseBpi>()))
				.Returns(expectedMarketPrice);

			var marketService = new MarketService(mockHttpClient, mockConfiguration.Object, mockMapper.Object);

			// Act
			var result = await marketService.GetPriceAsync(CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedMarketPrice, result);

			// Verifica se o mapper foi chamado com a entrada correta
			mockMapper.Verify(mapper => mapper.Map<ItemMarketPrice>(It.IsAny<GetPricingResponseBpi>()), Times.Once);
		}
	}
}