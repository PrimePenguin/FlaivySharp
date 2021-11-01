using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class SuppliersQueryResponse : CollectionBaseResponse
    {
        [JsonProperty("rows")]
        public SupplierRow[] Rows { get; set; }
    }

    public class SupplierRow
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
