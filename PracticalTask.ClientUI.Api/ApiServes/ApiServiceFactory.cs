using PracticalTask.ClientUI.Api.ApiServes.BaseServices;
using PracticalTask.ClientUI.Api.ApiServes.CustomerServices;
using PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;

namespace PracticalTask.ClientUI.Api.ApiServes;

public sealed class ApiServiceFactory
{
    public static BaseApiService GetApiService(IApiClient apiClient)
    {
        return new CustomerApiService(apiClient);
    }
}