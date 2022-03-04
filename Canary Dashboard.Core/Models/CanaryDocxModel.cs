namespace Canary_Dashboard.Core.Models;
public class CanaryDocxModel : ICanaryBaseModel
{
    public int ID { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public DateTime Timestamp { get; set; }
    public string InputChannel { get; set; }
    public bool IsTorRelay { get; set; }
    public string SourceIP { get; set; }
    public string Organization { get; set; }
    public string Hostname { get; set; }
    public string IP { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string UserAgent { get; set; }
    public object Location { get; set; }
    public object Referer { get; set; }
    public string Website { get; set; }
}
