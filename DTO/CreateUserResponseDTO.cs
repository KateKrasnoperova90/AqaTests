using System;
using System.Text.Json.Serialization;

public class CreateUserResponseDTO
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("job")]
    public string Job { get; set; }
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
}