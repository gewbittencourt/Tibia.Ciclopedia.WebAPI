using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
	public class CrossCutting
	{

		private readonly HttpClient _httpClient = new HttpClient();

		public async Task<double> GetPriceAsync()
		{
			var url = "https://api.coindesk.com/v1/bpi/currentprice.json";

			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode();

			var jsonResponse = await response.Content.ReadAsStringAsync();

			var price = JsonSerializer.Deserialize<Pricing>(jsonResponse);

            return price.Bpi.EUR.Rate_float;
		}
	}
}
