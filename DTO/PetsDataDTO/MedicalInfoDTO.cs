using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.PetsDataDTO;

public record MedicalInfoDTO

(
    [property: JsonPropertyName("vaccinated")]
    bool Vaccinated,
    [property: JsonPropertyName("spayedNeutered")]
    bool SpayedNeutered,
    [property: JsonPropertyName("microchipped")]
    bool Microchipped,
    [property: JsonPropertyName("specialNeeds")]
    bool SpecialNeeds,
    [property: JsonPropertyName("healthNotes")]
    string HealthNotes
);