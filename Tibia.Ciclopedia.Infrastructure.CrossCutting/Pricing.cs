using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting
{
	public class Pricing
	{
		[JsonPropertyName("bpi")]
		public Bpi Bpi { get; set; }
	}

	public class Bpi
	{
		[JsonPropertyName("EUR")]
		public Currency EUR { get; set; }
	}

	public class Currency
	{
		[JsonPropertyName("rate_float")]
		public double Rate_float { get; set; }
	}
}
