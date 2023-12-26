
using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;

namespace Canary_Dashboard.Core.Processors;

public interface IAPIProcessor
{
    Task<List<CanaryAlarm>> GetCanaryAlarmsAsync(List<CanaryTokenConfigurationModel> canaries);
}