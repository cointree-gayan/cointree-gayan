using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoinTree.WebAPI.Models
{
    public class CoinDetails
    {
        [JsonPropertyName("ask")]
        public double Ask { get; set; }

        [JsonPropertyName("bid")]
        public double Bid { get; set; }

        [JsonPropertyName("rate")]
        public double Rate { get; set; }

    }
}
