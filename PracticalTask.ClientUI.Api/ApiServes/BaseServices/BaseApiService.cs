using PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;
using PracticalTask.ClientUI.Api.Models.Responses;

namespace PracticalTask.ClientUI.Api.ApiServes.BaseServices;

public abstract class BaseApiService : IBaseApiService
{
    protected readonly IApiClient ApiClient;

    protected BaseApiService(IApiClient apiClient)
    {
        ArgumentNullException.ThrowIfNull(apiClient);
        ApiClient = apiClient;
    }

    public abstract Task<ApiResponse<T>> GetAllAsync<T>();
}