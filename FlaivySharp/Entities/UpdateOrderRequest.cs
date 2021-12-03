﻿using System;
using Newtonsoft.Json;

namespace FlaivySharp.Entities
{
    public class CreateOrUpdateOrderRequest
    {
        [JsonProperty("systembolagetOrderNumber")]
        public string SystembolagetOrderNumber { get; set; }

        [JsonProperty("storeNumber")]
        public string StoreNumber { get; set; }

        [JsonProperty("yourReference")]
        public string YourReference { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTimeOffset? DeliveryDate { get; set; }

        [JsonProperty("orderDate")]
        public DateTimeOffset? OrderDate { get; set; }

        [JsonProperty("orderState")]
        public string OrderState { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        [JsonProperty("deliveryInformation")]
        public string DeliveryInformation { get; set; }

        [JsonProperty("trackingCode")]
        public string TrackingCode { get; set; }

        [JsonProperty("orderRows")]
        public UpdateOrderRow[] OrderRows { get; set; }
    }

    public class UpdateOrderRow
    {
        [JsonProperty("systembolagetArticleNumber")]
        public string SystembolagetArticleNumber { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("orderedQuantity")]
        public int OrderedQuantity { get; set; }

        [JsonProperty("SBRowIndex")]
        public int? SbRowIndex { get; set; }
    }
}
