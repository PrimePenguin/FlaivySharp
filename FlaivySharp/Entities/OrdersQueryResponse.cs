using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class OrdersQueryResponse : CollectionBaseResponse
    {
        [JsonProperty("rows")] public List<Order> Orders { get; set; }
    }
}