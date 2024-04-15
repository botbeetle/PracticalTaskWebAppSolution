using PracticalTask.ClientUI.Api.Models.Requests.BaseRequests;
using PracticalTask.ClientUI.Api.Models.Responses;

namespace PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;

public interface IApiClient
{
    Task<ApiResponse<TResponseData>> ProcessRequestAsync<TResponseData>(IBaseRequest request);
}