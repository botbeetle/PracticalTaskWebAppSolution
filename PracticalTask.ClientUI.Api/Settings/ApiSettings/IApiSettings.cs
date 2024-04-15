namespace PracticalTask.ClientUI.Api.Settings.ApiSettings;

public interface IApiSettings
{
    public string BaseUrl { get; }
    public TimeSpan TimeOut { get; }
}