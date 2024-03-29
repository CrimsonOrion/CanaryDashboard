﻿using System.Text.Json.Serialization;

namespace Canary_Dashboard.Core.Models;

public class Asn
{
    [JsonPropertyName("route")]
    public string? Route { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("asn")]
    public string? AutonomousSystemNumber { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

