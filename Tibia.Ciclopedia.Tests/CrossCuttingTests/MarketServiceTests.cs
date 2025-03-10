﻿using AutoMapper;
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
			mockConfiguration.Setup(config => config["GetPriceAPI:Url"]).Returns("https://testapi.com");

			var mockHttpClient = new HttpClient(mockHttpMessageHandler.Object)
			{
				BaseAddress = new Uri("https://testapi.com")
			};

			var mockMapper = new Mock<IMapper>();

			var mockPricingResponse = new GetPricingResponse { };
			var expectedMarketPrice = new ItemMarketPrice {  };

			var jsonResponse = JsonSerializer.Serialize(mockPricingResponse);

			string price = "";
			using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
			{
				if (doc.RootElement.TryGetProperty("Price", out JsonElement priceElement))
				{
					price = priceElement.GetDouble().ToString();
				}
			}


				mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>(
					"SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(),
					ItExpr.IsAny<CancellationToken>()
				)
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent(price)
				});

			mockMapper
				.Setup(mapper => mapper.Map<ItemMarketPrice>(It.IsAny<GetPricingResponse>()))
				.Returns(expectedMarketPrice);

			var marketService = new MarketService(mockHttpClient, mockConfiguration.Object, mockMapper.Object);

			// Act
			var result = await marketService.GetPriceAsync(CancellationToken.None);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedMarketPrice, result);
			mockMapper.Verify(mapper => mapper.Map<ItemMarketPrice>(It.IsAny<GetPricingResponse>()), Times.Once);
		}
	}
}