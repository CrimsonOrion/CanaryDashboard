using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;

public class GeoInfo
{
    [JsonPropertyName("loc")]
    public string? Location { get; set; }

    [JsonPropertyName("org")]
    public string? Organization { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("ip")]
    public string? IP { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("postal")]
    public string? Postal { get; set; }

    [JsonPropertyName("asn")]
    public Asn? Asn { get; set; }

    [JsonPropertyName("readme")]
    public string? Readme { get; set; }
}

