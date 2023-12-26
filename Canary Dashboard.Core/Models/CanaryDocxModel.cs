namespace Canary_Dashboard.Core.Models;
public class CanaryDocxModel : CanaryBaseModel
{
    public string? UserAgent { get; set; }

    public CanaryDocxModel() { }

    public CanaryDocxModel(int id, CanaryAlarm alarm)
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
        UserAgent = alarm.HitInformation.UserAgent ?? "N/A";
        Website = alarm.Website;
    }
}
