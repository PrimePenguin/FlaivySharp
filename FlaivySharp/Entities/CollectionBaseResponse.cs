using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class CollectionBaseResponse
    {
        [JsonProperty("total")] public long Total { get; set; }

        [JsonProperty("page")] public long Page { get; set; }

        [JsonProperty("pageSize")] public long PageSize { get; set; }

        [JsonProperty("totalPages")] public long TotalPages { get; set; }
    }
}
