using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.OrderDataDTO;
public record ItemDTO
(
    [property: JsonPropertyName("productId")] 
    int ProductId,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("category")]
    string Category,
    [property: JsonPropertyName("quantity")]
    int Quantity,
    [property: JsonPropertyName("price")]
    decimal Price
);