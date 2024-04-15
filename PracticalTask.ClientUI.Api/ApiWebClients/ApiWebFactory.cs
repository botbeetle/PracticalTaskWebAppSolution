using PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;
using PracticalTask.ClientUI.Api.Settings.ApiSettings;
using Serilog;

namespace PracticalTask.ClientUI.Api.ApiWebClients;

public sealed class ApiWebFactory
{
    public static IApiClient GetApiClient(IApiSettings setting, ILogger? logger = null)
    {
        return new ApiClients.ApiClient(setting, logger);
    }
}