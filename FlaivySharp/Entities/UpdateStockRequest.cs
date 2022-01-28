using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class UpdateStockRequest
    {
        [JsonProperty("quantityInStock")]
        public int QuantityInStock { get; set; }

        [JsonProperty("availableQuantityInStock")]
        public int AvailableQuantityInStock { get; set; }
    }
    
    public class UpdateStockResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}