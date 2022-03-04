
using Canary_Dashboard.Core.Configuration;
using Canary_Dashboard.Core.Models;

namespace Canary_Dashboard.Core.Processors;

public interface IAPIProcessor
{
    CanaryDocxModel GetCanaryDocx(int id, CanaryJsonAPIModel alarm);
    CanaryFolderModel GetCanaryFolder(int id, CanaryJsonAPIModel alarm);
    Task<List<CanaryJsonAPIModel>> GetCanaryListAsync(List<CanaryTokenConfigurationModel> canaries);
    CanaryXlsxModel GetCanaryXlsx(int id, CanaryJsonAPIModel alarm);
}