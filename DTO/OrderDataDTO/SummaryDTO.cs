using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.OrderDataDTO;

public record SummaryDTO
(
    [property: JsonPropertyName("itemsTotal")] 
    decimal ItemsTotal,
    [property: JsonPropertyName("deliveryFee")]
    decimal  DeliveryFee,
    [property: JsonPropertyName("discount")]
    decimal Discount,
    [property: JsonPropertyName("finalTotal")]
    decimal FinalTotal
);