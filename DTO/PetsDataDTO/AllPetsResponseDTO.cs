using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.PetsDataDTO;

public record AllPetsResponseDTO

(
    List<PetsDTO> Data
);