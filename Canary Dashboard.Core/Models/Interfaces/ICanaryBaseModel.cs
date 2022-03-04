namespace Canary_Dashboard.Core.Models;
public interface ICanaryBaseModel
{
    int ID { get; set; }
    string Type { get; set; }
    string City { get; set; }
    string Country { get; set; }
    string InputChannel { get; set; }
    bool IsTorRelay { get; set; }
    double Latitude { get; set; }
    double Longitude { get; set; }
    string Organization { get; set; }
    string IP { get; set; }
    string SourceIP { get; set; }
    string State { get; set; }
    DateTime Timestamp { get; set; }
    string Zip { get; set; }
    string Website { get; set; }
    string Name { get; set; }
}