using PracticalTask.ClientUI.ConsoleAction.InputAction;
using PracticalTask.ClientUI.ConsoleAction.OutputAction;

namespace PracticalTask.ClientUI.ConsoleAction;

public sealed class ConsoleActionFactory
{
    public static IOutputConsole GetOutput()
    {
        return new OutputConsole();
    }

    public static IInputConsole GetInput()
    {
        return new InputConsole();
    }
}