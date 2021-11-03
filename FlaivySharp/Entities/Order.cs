using System;
using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class Order
    {
        [JsonProperty("orderRows")]
        public OrderRow[] OrderRows { get; set; }

        [JsonProperty("orderState")]
        public string OrderState { get; set; }

        [JsonProperty("cancelled")]
        public bool Cancelled { get; set; }

        [JsonProperty("orderNumber")]
        public long OrderNumber { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("yourReference")]
        public string YourReference { get; set; }

        [JsonProperty("orderOrigin")]
        public string OrderOrigin { get; set; }

        [JsonProperty("ourReference")]
        public string OurReference { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("systembolagetOrderNumber")]
        public string SystembolagetOrderNumber { get; set; }

        [JsonProperty("systembolagetReturnCode")]
        public string SystembolagetReturnCode { get; set; }

        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        [JsonProperty("deliveryName")]
        public string DeliveryName { get; set; }

        [JsonProperty("deliveryAddress")]
        public string DeliveryAddress { get; set; }

        [JsonProperty("deliveryZipCode")]
        public string DeliveryZipCode { get; set; }

        [JsonProperty("deliveryCity")]
        public string DeliveryCity { get; set; }

        [JsonProperty("deliveryCountry")]
        public string DeliveryCountry { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTimeOffset DeliveryDate { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("endCustomer")]
        public EndCustomer EndCustomer { get; set; }
    }

    public class EndCustomer
    {
        [JsonProperty("customerNumber")] 
        public long CustomerNumber { get; set; }
    }

    public class OrderRow
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("deliveredQuantity")]
        public long DeliveredQuantity { get; set; }

        [JsonProperty("orderedQuantity")]
        public long OrderedQuantity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("article")]
        public Article Article { get; set; }
    }

    public class Article
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("systembolagetArticleNumber")]
        public long SystembolagetArticleNumber { get; set; }

        [JsonProperty("articleNumber")]
        public long ArticleNumber { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("alcoholPercentage")]
        public long AlcoholPercentage { get; set; }

        [JsonProperty("colliSize")]
        public long ColliSize { get; set; }
    }
}