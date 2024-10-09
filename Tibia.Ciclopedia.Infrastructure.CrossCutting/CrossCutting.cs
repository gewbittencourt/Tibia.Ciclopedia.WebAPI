using Polly;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
	public class CrossCutting : ICrossCutting
	{

		private readonly HttpClient _httpClient;

		public CrossCutting(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<double> GetPriceAsync()
		{
			var retryPolicy = Policy
				.Handle<Exception>()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(1));

			var timeoutPolicy = Policy
				.TimeoutAsync(TimeSpan.FromSeconds(5));

			return await retryPolicy.WrapAsync(timeoutPolicy).ExecuteAsync(async () =>
			{
				var url = "https://api.coindesk.com/v1/bpi/currentprice.json";

				var response = await _httpClient.GetAsync(url);
				response.EnsureSuccessStatusCode();

				var jsonResponse = await response.Content.ReadAsStringAsync();

				var price = JsonSerializer.Deserialize<Pricing>(jsonResponse);

				return price.Bpi.EUR.Rate_float;
			});
		}
	}
}
