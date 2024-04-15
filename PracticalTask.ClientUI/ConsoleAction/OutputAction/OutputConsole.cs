namespace PracticalTask.ClientUI.ConsoleAction.OutputAction;

public sealed class OutputConsole : IOutputConsole
{
    public void DrawTableCross() => Console.Write('+');

    public void DrawTableLineHorizontal(int length)
    {
        for (var i = 0; i < length; i++)
        {
            Console.Write('-');
        }
    }

    public void DrawTableLineHorizontalDouble(int length)
    {
        for (var i = 0; i < length; i++)
        {
            Console.Write('=');
        }
    }

    public void DrawTableLineVertical() => Console.Write('|');

    public void NewLine() => Console.WriteLine();

    public void DrawValueInCell(int capacity, string value)
    {
        Console.Write($" {value} ");
        for (var i = 0; i < capacity - value.Length; i++)
        {
            Console.Write(" ");
        }
    }

    public void WriteMessage(string message) => Console.WriteLine(message);

    public void Reset()
    {
        Console.Clear();
    }
}