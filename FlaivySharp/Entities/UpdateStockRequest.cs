using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class UpdateStockRequest
    {
        [JsonProperty("quantityInStock")]
        public int QuantityInStock { get; set; }
    }
}
