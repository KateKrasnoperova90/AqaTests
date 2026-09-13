using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.PetsDataDTO;

public record PetsDTO

(
    [property: JsonPropertyName("id")]
    string Id,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("species")]
    string Species,
    [property: JsonPropertyName("breed")]
    string Breed,
    [property: JsonPropertyName("ageMonths")]
    int AgeMonths,
    [property: JsonPropertyName("size")]
    string Size,
    [property: JsonPropertyName("status")]
    string Status,
    [property: JsonPropertyName("price")]
    string Price,
    [property: JsonPropertyName("currency")]
    string Currency,
    [property: JsonPropertyName("goodWithKids")]
    bool GoodWithKids,
    [property: JsonPropertyName("createdAt")]
    string CreatedAt,
    [property: JsonPropertyName("updatedAt")]
    string UpdatedAt,
    [property: JsonPropertyName("medicalInfo")]
    MedicalInfoDTO MedicalInfo
);