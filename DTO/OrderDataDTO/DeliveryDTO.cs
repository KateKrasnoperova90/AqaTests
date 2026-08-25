using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.OrderDataDTO;

public record DeliveryDTO
(
    [property: JsonPropertyName("type")] 
    string Type,
    [property: JsonPropertyName("status")]
    string Status,
    [property: JsonPropertyName("estimatedDate")]
    string EstimatedDate,
    [property: JsonPropertyName("trackingNumber")]
    string TrackingNumber
);