namespace PracticalTask.WebApp.Core.DataModels.Sheets;

public sealed class SheetResult<T>
{
    public int SheetNumber { get; set; }
    public int RecordNumber { get; set; }
    public int TotalCount { get; set; }
    public List<T> Items { get; set; }

    public override string ToString()
    {
        return $"SheetNumber:{SheetNumber}; RecordNumber:{RecordNumber}; TotalCount:{TotalCount} ItemsCount:{Items?.Count}";
    }
}