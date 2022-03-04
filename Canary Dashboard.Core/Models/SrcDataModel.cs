using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;
public class SrcDataModel
{
    [JsonPropertyName("windows_desktopini_access_domain")]
    public string AccessDomain { get; set; }

    [JsonPropertyName("windows_desktopini_access_hostname")]
    public string AccessHostname { get; set; }

    [JsonPropertyName("windows_desktopini_access_username")]
    public string AccessUsername { get; set; }
}
