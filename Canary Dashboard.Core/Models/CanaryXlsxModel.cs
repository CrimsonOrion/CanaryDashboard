namespace Canary_Dashboard.Core.Models;
public class CanaryXlsxModel : CanaryBaseModel
{
    public string? AsnRoute { get; set; }
    public string? AsnType { get; set; }
    public string? AsnNumber { get; set; }
    public string? AsnDomain { get; set; }
    public string? AsnName { get; set; }
    public string? UserAgent { get; set; }

    public CanaryXlsxModel() { }

    public CanaryXlsxModel(int id, CanaryAlarm alarm)
    {
        ID = id;
        Name = alarm.Name;
        TokenType = alarm.HitInformation.TokenType;
        Timestamp = alarm.HitInformation.TimeOfHitDateTime ?? new();
        InputChannel = alarm.HitInformation.InputChannel ?? "N/A";
        IsTorRelay = alarm.HitInformation.IsTorRelay ?? false;
        SourceIP = alarm.HitInformation.SourceIP ?? "0.0.0.0";
        Organization = alarm.HitInformation.GeoInfo?.Organization ?? "N/A";
        Hostname = alarm.HitInformation.GeoInfo?.Hostname ?? "N/A";
        IP = alarm.HitInformation.GeoInfo?.IP ?? "0.0.0.0";
        City = alarm.HitInformation.GeoInfo?.City ?? "N/A";
        State = alarm.HitInformation.GeoInfo?.Region ?? "N/A";
        Country = alarm.HitInformation.GeoInfo?.Country ?? "N/A";
        Zip = alarm.HitInformation.GeoInfo?.Postal ?? "N/A";
        Coordinates = alarm.HitInformation.GeoInfo?.Location ?? "0,0";
        AsnDomain = alarm.HitInformation.GeoInfo?.Asn?.Domain ?? "N/A";
        AsnName = alarm.HitInformation.GeoInfo?.Asn?.Name ?? "N/A";
        AsnNumber = alarm.HitInformation.GeoInfo?.Asn?.AutonomousSystemNumber ?? "N/A";
        AsnRoute = alarm.HitInformation.GeoInfo?.Asn?.Route ?? "N/A";
        AsnType = alarm.HitInformation.GeoInfo?.Asn?.Type ?? "N/A";
        UserAgent = alarm.HitInformation.UserAgent ?? "N/A";
        Website = alarm.Website;
    }
}