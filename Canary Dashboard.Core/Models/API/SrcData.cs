using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;

public class SrcData
{
    [JsonPropertyName("windows_desktopini_access_domain")]
    public string? WindowsDesktopiniAccessDomain { get; set; }

    [JsonPropertyName("windows_desktopini_access_hostname")]
    public string? WindowsDesktopiniAccessHostname { get; set; }

    [JsonPropertyName("windows_desktopini_access_username")]
    public string? WindowsDesktopiniAccessUsername { get; set; }
}

