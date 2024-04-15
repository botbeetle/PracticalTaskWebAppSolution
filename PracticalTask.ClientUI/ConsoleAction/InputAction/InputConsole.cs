namespace PracticalTask.ClientUI.ConsoleAction.InputAction;

public sealed class InputConsole : IInputConsole
{
    private const char SmallQuitCharacter = 'q';
    private const char HugeQuitCharacter = 'Q';

    public async Task<bool> PressToExit()
    {
        while (Console.KeyAvailable == false)
        {
            await Task.Delay(250);
        }

        var consoleKey = Console.ReadKey(true);

        return consoleKey.KeyChar == SmallQuitCharacter || consoleKey.KeyChar == HugeQuitCharacter;
    }
}