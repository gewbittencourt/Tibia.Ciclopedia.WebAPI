using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Tibia.Ciclopedia.Domain.Items.DTO;
using Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
    public class MarketService : IMarketService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiURL;
		private readonly IMapper _mapper;

		public MarketService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
		{
			_httpClient = httpClient;
			_apiURL = configuration["GetPriceAPI:Url"];
			_mapper = mapper;
		}

		public async Task<ItemMarketPrice> GetPriceAsync(CancellationToken cancellationToken)
		{

			var response = await _httpClient.GetAsync(_apiURL);
			response.EnsureSuccessStatusCode();

			var jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);

			var pricingResponse = JsonSerializer.Deserialize<GetPricingResponseBpi>(jsonResponse);

			return _mapper.Map<ItemMarketPrice>(pricingResponse);
		}
	}
}
