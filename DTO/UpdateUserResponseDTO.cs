using System;
using System.Text.Json.Serialization;

public class UpdateUserResponseDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("job")]
    public string Job { get; set; }
}