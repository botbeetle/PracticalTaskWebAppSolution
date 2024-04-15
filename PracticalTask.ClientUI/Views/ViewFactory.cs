using PracticalTask.ClientUI.Api.ApiServes.BaseServices;
using PracticalTask.ClientUI.ConsoleAction.InputAction;
using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using PracticalTask.ClientUI.Tools.TableTools;
using PracticalTask.ClientUI.Views.MainViews;
using Serilog;

namespace PracticalTask.ClientUI.Views;

public class ViewFactory
{
    public static IView GetViewManager<T>(IOutputConsole output, IInputConsole input, ITableTool<T> table, IBaseApiService service, ILogger logger)
    {
        return new MainView<T>(output, input, table, service, logger);
    }
}