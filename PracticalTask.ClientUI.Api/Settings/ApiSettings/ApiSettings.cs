namespace PracticalTask.ClientUI.Api.Settings.ApiSettings;

public record ApiSettings : IApiSettings
{
    public ApiSettings()
    {

    }

    public ApiSettings(string baseUrl, TimeSpan timeOut)
    {
        BaseUrl = baseUrl;
        TimeOut = timeOut;
    }

    public string BaseUrl { get; } = "https://localhost:7130";
    public TimeSpan TimeOut { get; } = TimeSpan.FromSeconds(10);
}