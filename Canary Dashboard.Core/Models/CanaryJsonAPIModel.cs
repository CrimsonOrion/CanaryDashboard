using System.Text.Json;
using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;
public class CanaryJsonAPIModel
{
    [JsonPropertyName("is_tor_relay")]
    public bool IsTorRelay { get; set; }

    [JsonPropertyName("input_channel")]
    public string InputChannel { get; set; }

    [JsonPropertyName("geo_info")]
    public object GeoInfo { get; set; }

    [JsonPropertyName("src_ip")]
    public string SrcIp { get; set; }

    [JsonPropertyName("src_data")]
    public SrcDataModel SrcData { get; set; }

    [JsonPropertyName("referer")]
    public object Referer { get; set; }

    [JsonPropertyName("location")]
    public object Location { get; set; }

    [JsonPropertyName("useragent")]
    public string Useragent { get; set; }

    public DateTime Timestamp { get; set; }
    public string Website { get; set; }
    public string Name { get; set; }

    public static Dictionary<string, CanaryJsonAPIModel> FromJson(string json) => JsonSerializer.Deserialize<Dictionary<string, CanaryJsonAPIModel>>(json, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
}