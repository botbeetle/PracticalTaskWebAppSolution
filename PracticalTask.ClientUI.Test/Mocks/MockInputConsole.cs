using PracticalTask.ClientUI.ConsoleAction.InputAction;

namespace PracticalTask.ClientUI.Test.Mocks;

internal sealed class MockInputConsole : IInputConsole
{
    public event EventHandler? ReadUserKeyEventClicked;
    public bool ReadUserKeyReturn = true;

    public async Task<bool> PressToExit()
    {
        await Task.Delay(250);
        ReadUserKeyEventClicked?.Invoke(this, EventArgs.Empty);
        return ReadUserKeyReturn;
    }
}