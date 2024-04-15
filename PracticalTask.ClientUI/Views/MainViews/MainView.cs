using PracticalTask.ClientUI.Api.ApiServes.BaseServices;
using PracticalTask.ClientUI.ConsoleAction.InputAction;
using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using PracticalTask.ClientUI.Tools.TableTools;
using Serilog;


namespace PracticalTask.ClientUI.Views.MainViews;

public class MainView<T> : IView
{
    private readonly IOutputConsole _output;
    private readonly IInputConsole _input;
    private readonly ITableTool<T> _table;
    private readonly IBaseApiService _service;
    private readonly ILogger? _logger;

    public MainView(
        IOutputConsole output,
        IInputConsole input,
        ITableTool<T> table,
        IBaseApiService service,
        ILogger? logger = null)
    {

        ArgumentNullException.ThrowIfNull(table);
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(output);
        ArgumentNullException.ThrowIfNull(input);


        _output = output;
        _table = table;
        _service = service;
        _input = input;
        _logger = logger;
    }

    public async Task FetchAndDisplayDataAsync()
    {
        while (true)
        {
            Reset();
            await ProcessDataAsync();
            var exit = await IsUserExited();
            if (exit)
            {
                return;
            }
        }
    }

    private void Reset()
    {
        if (Console.IsOutputRedirected == false)
        {
            _output.Reset();
        }
    }

    private async Task ProcessDataAsync()
    {
        try
        {
            var customersResponse = await _service.GetAllAsync<IReadOnlyCollection<T>>();


            if (customersResponse is { IsFailed: false, Data: not null })
            {
                _table.DrawTable(customersResponse.Data);
            }
            else if (!string.IsNullOrWhiteSpace(customersResponse.ErrorMessage))
            {
                var msg = $"Fetching data failed. Reason: {customersResponse.ErrorMessage}";
                _logger?.Error(msg);
                _output.WriteMessage($"\n{msg}");
            }
            else
            {
                var msg = $"Fetching data failed. Reason: {customersResponse.ErrorMessage}";
                _logger?.Error(msg);
                _output.WriteMessage($"\n{msg}");
            }
        }
        catch (Exception exp)
        {
            _logger?.Error(exp, nameof(ProcessDataAsync));
        }
    }

    private async Task<bool> IsUserExited()
    {
        _output.WriteMessage("\nPress 'q' to quit or any other key to reload data...");
        return await _input.PressToExit();
    }
}