using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;

public class Hit
{
    [JsonPropertyName("time_of_hit")]
    public double? TimeOfHit { get; set; }

    [JsonPropertyName("src_ip")]
    public string? SourceIP { get; set; }

    [JsonPropertyName("geo_info")]
    public GeoInfo? GeoInfo { get; set; }

    [JsonPropertyName("is_tor_relay")]
    public bool? IsTorRelay { get; set; }

    [JsonPropertyName("input_channel")]
    public string? InputChannel { get; set; }

    [JsonPropertyName("src_data")]
    public SrcData? SourceData { get; set; }

    [JsonPropertyName("useragent")]
    public string? UserAgent { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    [JsonIgnore]
    public DateTime? TimeOfHitDateTime => new DateTime(1970, 1, 1).AddSeconds(TimeOfHit ?? 0).ToLocalTime();
}

