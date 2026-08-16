namespace AqaTest;

using System.Text.Json.Serialization;

public class CreateUserRequestDTO
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("job")]
    public string Job { get; set; }
}