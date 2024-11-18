using System.Text.Json.Serialization;
using TDV.BegetClient.JsonConverters;

namespace TDV.BegetClient.Models.Domain
{
    public class BegetZone
    {
        public int Id { get; set; }
        public string Zone { get; set; }
        public decimal Price { get; set; }
        [JsonPropertyName("price_renew")]
        public decimal PriceRenew { get; set; }
        [JsonPropertyName("price_idn")]
        public decimal? PriceIdn { get; set; }
        [JsonPropertyName("price_idn_renew")]
        public decimal? PriceIdnRenew { get; set; }
        [JsonPropertyName("is_idn")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool IsIdn { get; set; } = false;
        [JsonPropertyName("is_national")]
        [JsonConverter(typeof(JsonBoolConverter))]
        public bool? IsNational { get; set; }
        [JsonPropertyName("min_period")]
        public int MinRegistrePeriodYears { get; set; }
        [JsonPropertyName("max_period")]
        public int MaxRegistrePeriodYears { get; set; }

    }
}
