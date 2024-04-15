using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using PracticalTask.ClientUI.Tools.TableTools;

namespace PracticalTask.ClientUI.Tools;

public sealed class ToolsFactory
{
    public static ITableTool<T> GetTableTool<T>(IOutputConsole output)
    {
        return new TableTool<T>(output);
    }
}