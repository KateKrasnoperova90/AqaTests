using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.UsersDataDTO;

public record AddressUserDTO
(
    [property: JsonPropertyName("city")]
    string City,
    [property: JsonPropertyName("street")]
    string Street,
    [property: JsonPropertyName("geo")]
    GeoDTO Geo
);