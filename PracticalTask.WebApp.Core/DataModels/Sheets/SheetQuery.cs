namespace PracticalTask.WebApp.Core.DataModels.Sheets;

public sealed class SheetQuery
{
    public int StartIndex { get; set; }
    public int SheetNumber { get; set; }
    public int SheetSize { get; set; }

    public override string ToString()
    {
        return $"StartIndex:{StartIndex}; SheetNumber:{SheetNumber}; SheetSize:{SheetSize}";
    }
}