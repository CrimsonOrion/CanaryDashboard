using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;

public class Response
{
    [JsonPropertyName("hits")]
    public List<Hit> Hits { get; set; } = [];

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
}