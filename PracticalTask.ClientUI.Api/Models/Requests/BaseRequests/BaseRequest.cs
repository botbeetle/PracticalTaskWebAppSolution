namespace PracticalTask.ClientUI.Api.Models.Requests.BaseRequests;

public abstract class BaseRequest : IBaseRequest
{
    public abstract string Endpoint { get; set; }
    public abstract HttpMethod Method { get; set; }
}