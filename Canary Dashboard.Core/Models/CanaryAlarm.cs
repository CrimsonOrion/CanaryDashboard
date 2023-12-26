namespace Canary_Dashboard.Core.Models;
public class CanaryAlarm
{
    public required string Name { get; set; }
    public required string Website { get; set; }
    public Hit HitInformation { get; set; } = new();
}