using PracticalTask.ClientUI.Api.Settings.ApiSettings;

namespace PracticalTask.ClientUI.Api.Settings;

public sealed class SettingFactory
{
    public static IApiSettings GetSetting()
    {
        return new ApiSettings.ApiSettings();
    }

    public static IApiSettings GetSetting(string baseUrl, TimeSpan timeOut)
    {
        return new ApiSettings.ApiSettings(baseUrl, timeOut);
    }
}