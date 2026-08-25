using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.UsersDataDTO;

public record DataDTO
(
    [property: JsonPropertyName("data")]
    IReadOnlyList<UserDTO> Data
);