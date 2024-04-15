using Newtonsoft.Json;
using PracticalTask.ClientUI.Api.Models.Requests.BaseRequests;
using PracticalTask.ClientUI.Api.Models.Responses;
using PracticalTask.ClientUI.Api.Settings.ApiSettings;
using Serilog;

namespace PracticalTask.ClientUI.Api.ApiWebClients.ApiClients;

public sealed class ApiClient : IApiClient, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly IApiSettings _settings;
    private readonly ILogger? _logger;

    public ApiClient(IApiSettings settings, ILogger? logger = null)
    {
        ArgumentNullException.ThrowIfNull(settings);

        _logger = logger;
        _settings = settings;
        _httpClient = new HttpClient();
    }

    public void Dispose() => _httpClient.Dispose();

    public async Task<ApiResponse<TResponseData>> ProcessRequestAsync<TResponseData>(IBaseRequest request)
    {
        try
        {
            var url = _settings.BaseUrl + request.Endpoint;
            var requestMessage = new HttpRequestMessage(request.Method, url);
            var cancellationToken = new CancellationTokenSource(_settings.TimeOut).Token;
            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);

            if (response.IsSuccessStatusCode == false)
            {
                return new ApiResponse<TResponseData>(default, true, $"Failed response - {response.StatusCode}");
            }

            var responseMessage = await response.Content.ReadAsStringAsync(cancellationToken);
            var deserialized = JsonConvert.DeserializeObject<TResponseData>(responseMessage);
            return new ApiResponse<TResponseData>(deserialized);
        }
        catch (Exception exp)
        {
            _logger?.Error(exp, $"request: {request}");
            return new ApiResponse<TResponseData>(default, true, $"Exception raised - {exp.Message}");
        }
    }
}