using PracticalTask.ClientUI.Api.Models.Requests.BaseRequests;

namespace PracticalTask.ClientUI.Api.Models.Requests.CustomersRequests;

public class GetCustomersRequest : IBaseRequest
{
    public string Endpoint => "/api/Customers";
    public HttpMethod Method => HttpMethod.Get;
}