using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.OrderDataDTO;
public record CustomerDTO
(
    [property: JsonPropertyName("id")] 
    int Id,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("email")]
    string Email,
    [property: JsonPropertyName("phone")]
    string Phone,
    [property: JsonPropertyName("address")]
    AddressDTO Address
);