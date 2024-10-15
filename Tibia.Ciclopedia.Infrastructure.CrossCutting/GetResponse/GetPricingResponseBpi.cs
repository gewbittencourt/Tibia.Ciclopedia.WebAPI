using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Infrastructure.CrossCutting.GetResponse
{
    public class GetPricingResponseBpi
    {
        [JsonPropertyName("bpi")]
        public GetPriceResponseEUR Bpi { get; set; }
    }
}
