using PracticalTask.ClientUI.Api.ApiServes.BaseServices;
using PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;
using PracticalTask.ClientUI.Api.Models.Requests.CustomersRequests;
using PracticalTask.ClientUI.Api.Models.Responses;

namespace PracticalTask.ClientUI.Api.ApiServes.CustomerServices;

public sealed class CustomerApiService : BaseApiService, ICustomerApiService
{
    public CustomerApiService(IApiClient apiClient) : base(apiClient)
    {
        ArgumentNullException.ThrowIfNull(apiClient);
    }

    public override async Task<ApiResponse<T>> GetAllAsync<T>()
    {
        return await ApiClient.ProcessRequestAsync<T>(new GetCustomersRequest());
    }
}