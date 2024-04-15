namespace PracticalTask.ClientUI.Api.Models.Requests.BaseRequests;

public interface IBaseRequest
{
    public string Endpoint { get; }
    public HttpMethod Method { get; }

};