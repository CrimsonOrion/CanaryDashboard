using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;

using RestSharp;

namespace Canary_Dashboard.Core.Processors;
public class CanaryAPIProcessor : IAPIProcessor
{
    public RestClient Client { get; set; }
    public CanaryAPIProcessor() => Client ??= new()
    {
        AcceptedContentTypes = ["application/json"]
    };

    public async Task<List<CanaryAlarm>> GetCanaryAlarmsAsync(List<CanaryTokenConfigurationModel> canaries)
    {
        List<CanaryAlarm> canaryAlarms = [];
        foreach (CanaryTokenConfigurationModel canary in canaries)
        {
            var uri = $@"https://canarytokens.org/download?fmt=incidentlist_json&token={canary.Token}&auth={canary.Auth}";
            Response response = await GetInsidentListAsync(uri);
            foreach (Hit hit in response.Hits)
            {
                CanaryAlarm alarm = new()
                {
                    Name = canary.Name,
                    Website = $@"https://canarytokens.org/history?token={canary.Token}&auth={canary.Auth}",
                    HitInformation = hit
                };
                canaryAlarms.Add(alarm);
            }
        }
        return [.. canaryAlarms.OrderBy(_ => _.Name).ThenBy(_ => _.HitInformation.TimeOfHit)];
    }

    private async Task<Response> GetInsidentListAsync(string uri)
    {
        RestRequest request = new(uri, Method.Get);
        RestResponse response = await Client.ExecuteAsync(request);
        return Client.Serializers.DeserializeContent<Response>(response)
            ?? new();
    }
}