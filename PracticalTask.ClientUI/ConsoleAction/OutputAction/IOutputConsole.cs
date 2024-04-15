namespace PracticalTask.ClientUI.ConsoleAction.OutputAction;

public interface IOutputConsole
{
    void DrawTableCross();
    void DrawTableLineHorizontal(int length);
    void DrawTableLineHorizontalDouble(int length);
    void DrawTableLineVertical();
    void NewLine();
    void DrawValueInCell(int capacity, string value);
    void WriteMessage(string message);
    void Reset();
}