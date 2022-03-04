using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;

using System.Text.Json;

namespace Canary_Dashboard.Core.Processors;
public class CanaryAPIProcessor : IAPIProcessor
{
    public CanaryAPIProcessor()
    {

    }

    public async Task<List<CanaryJsonAPIModel>> GetCanaryListAsync(List<CanaryTokenConfigurationModel> canaries)
    {
        List<CanaryJsonAPIModel> canaryList = new();
        foreach (CanaryTokenConfigurationModel canary in canaries)
        {
            var uri = $@"http://canarytokens.org/download?fmt=incidentlist_json&token={canary.Token}&auth={canary.Auth}";
            var json = await GetJsonStringAsync(uri);
            Dictionary<string, CanaryJsonAPIModel> canaryAPI = CanaryJsonAPIModel.FromJson(json);
            foreach (KeyValuePair<string, CanaryJsonAPIModel> alarm in canaryAPI)
            {
                alarm.Value.GeoInfo = alarm.Value.GeoInfo.ToString() != "" ?
                    JsonSerializer.Deserialize<GeoInfoModel>(alarm.Value.GeoInfo.ToString()) :
                    new() { Hostname = "N/A", Ip = "0.0.0.0", City = "N/A", Country = "N/A", Loc = "0,0", Org = "N/A", Phone = "N/A", Postal = "N/A", Region = "N/A" };
                alarm.Value.Timestamp = new DateTime(1970, 1, 1).AddSeconds(Convert.ToDouble(alarm.Key)).ToLocalTime();
                alarm.Value.Website = $@"http://canarytokens.org/history?token={canary.Token}&auth={canary.Auth}";
                alarm.Value.Name = canary.Name;
                canaryList.Add(alarm.Value);
            }
        }

        return canaryList;
    }

    public CanaryDocxModel GetCanaryDocx(int id, CanaryJsonAPIModel alarm)
    {
        GeoInfoModel geoInfo = alarm.GeoInfo as GeoInfoModel;
        CanaryDocxModel canary = new()
        {
            ID = id,
            Name = alarm.Name,
            InputChannel = alarm.InputChannel,
            IsTorRelay = alarm.IsTorRelay,
            SourceIP = alarm.SrcIp,
            Timestamp = alarm.Timestamp,
            Location = alarm.Location,
            Referer = alarm.Referer,
            UserAgent = alarm.Useragent,
            Website = alarm.Website,
            City = geoInfo.City,
            Country = geoInfo.Country,
            Latitude = Convert.ToDouble(geoInfo.Loc.Split(',')[0]),
            Longitude = Convert.ToDouble(geoInfo.Loc.Split(',')[1]),
            Organization = geoInfo.Org,
            IP = geoInfo.Ip,
            State = geoInfo.Region,
            Zip = geoInfo.Postal,
            Hostname = geoInfo.Hostname,
            Phone = geoInfo.Phone
        };

        return canary;
    }

    public CanaryFolderModel GetCanaryFolder(int id, CanaryJsonAPIModel alarm)
    {
        GeoInfoModel geoInfo = alarm.GeoInfo as GeoInfoModel;

        CanaryFolderModel canary = new()
        {
            ID = id,
            Name = alarm.Name,
            InputChannel = alarm.InputChannel,
            IsTorRelay = alarm.IsTorRelay,
            SourceIP = alarm.SrcIp,
            Timestamp = alarm.Timestamp,
            AccessDomain = alarm.SrcData?.AccessDomain,
            AccessHostname = alarm.SrcData?.AccessHostname,
            AccessUsername = alarm.SrcData?.AccessUsername,
            Website = alarm.Website,
            City = geoInfo.City,
            Country = geoInfo.Country,
            Latitude = Convert.ToDouble(geoInfo.Loc.Split(',')[0]),
            Longitude = Convert.ToDouble(geoInfo.Loc.Split(',')[1]),
            Organization = geoInfo.Org,
            IP = geoInfo.Ip,
            State = geoInfo.Region,
            Zip = geoInfo.Postal,
            Hostname = geoInfo.Hostname,
            AsnDomain = geoInfo.Asn.Domain,
            AsnName = geoInfo.Asn.Name,
            AsnNumber = geoInfo.Asn.AsnNumber,
            AsnRoute = geoInfo.Asn.Route,
            AsnType = geoInfo.Asn.Type,
        };

        return canary;
    }

    public CanaryXlsxModel GetCanaryXlsx(int id, CanaryJsonAPIModel alarm)
    {
        GeoInfoModel geoInfo = alarm.GeoInfo as GeoInfoModel;

        CanaryXlsxModel canary = new()
        {
            ID = id,
            Name = alarm.Name,
            InputChannel = alarm.InputChannel,
            IsTorRelay = alarm.IsTorRelay,
            SourceIP = alarm.SrcIp,
            Timestamp = alarm.Timestamp,
            Website = alarm.Website,
            Referer = alarm.Referer,
            UserAgent = alarm.Useragent,
            City = geoInfo.City,
            Country = geoInfo.Country,
            Latitude = Convert.ToDouble(geoInfo.Loc.Split(',')[0]),
            Longitude = Convert.ToDouble(geoInfo.Loc.Split(',')[1]),
            Organization = geoInfo.Org,
            IP = geoInfo.Ip,
            State = geoInfo.Region,
            Zip = geoInfo.Postal,
            Hostname = geoInfo.Hostname,
            AsnDomain = geoInfo.Asn.Domain,
            AsnName = geoInfo.Asn.Name,
            AsnNumber = geoInfo.Asn.AsnNumber,
            AsnRoute = geoInfo.Asn.Route,
            AsnType = geoInfo.Asn.Type,
        };

        return canary;
    }

    private static async Task<string> GetJsonStringAsync(string uri)
    {
        HttpClient client = new();
        HttpResponseMessage request = await client.GetAsync(uri);
        var json = await request.Content.ReadAsStringAsync();
        return json;
    }
}