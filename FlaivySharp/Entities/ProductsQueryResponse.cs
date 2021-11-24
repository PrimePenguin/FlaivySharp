using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class ProductsQueryResponse : CollectionBaseResponse
    {
        [JsonProperty("rows")]
        public FlaivyProduct[] Products { get; set; }
    }

    public class FlaivyProduct
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("articleNumber")]
        public string ArticleNumber { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("volume")]
        public double? Volume { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("alcoholPercentage")]
        public double AlcoholPercentage { get; set; }

        [JsonProperty("colliSize")]
        public long ColliSize { get; set; }

        [JsonProperty("supplier")]
        public Brand Supplier { get; set; }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }
    }

    public class Brand
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
