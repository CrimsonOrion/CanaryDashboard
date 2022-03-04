using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;
public class GeoInfoModel
{
    [JsonPropertyName("loc")]
    public string Loc { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("hostname")]
    public string Hostname { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; }

    [JsonPropertyName("org")]
    public string Org { get; set; }

    [JsonPropertyName("postal")]
    public string Postal { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }

    [JsonPropertyName("asn")]
    public AsnModel Asn { get; set; }
}