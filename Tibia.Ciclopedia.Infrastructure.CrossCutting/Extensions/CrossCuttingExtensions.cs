using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting.Extensions
{
	public static class CrossCuttingExtensions
	{
		public static IServiceCollection AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddHttpClient<IMarketService, MarketService>()
				.AddPolicyHandler(GetRetryPolicy());

			return services;
		}

		private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
		{
			return HttpPolicyExtensions
				.HandleTransientHttpError()
				.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(1));
		}
	}
}
