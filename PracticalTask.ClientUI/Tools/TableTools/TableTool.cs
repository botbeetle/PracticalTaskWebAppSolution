using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using System.ComponentModel;
using System.Reflection;

namespace PracticalTask.ClientUI.Tools.TableTools;

public sealed class TableTool<TModel> : ITableTool<TModel>
{
    private const string NullValueTable = "";
    private const string DateFormat = "dd/MM/yyyy";
    private const int LengthSpaceAroundValue = 2;

    private readonly Dictionary<PropertyInfo, int> _cellsLengthBasic;
    private readonly List<Dictionary<PropertyInfo, string>> _convertedValuesTable = new();
    private readonly IOutputConsole _outputHelper;

    private Dictionary<PropertyInfo, int> _cellsLengthUpdated;

    public TableTool(IOutputConsole outputHelper)
    {
        ArgumentNullException.ThrowIfNull(outputHelper);

        _outputHelper = outputHelper;

        _cellsLengthBasic = CalculateBasicCascade();
        _cellsLengthUpdated = new Dictionary<PropertyInfo, int>(_cellsLengthBasic);
    }

    public void DrawTable(IReadOnlyCollection<TModel> data)
    {
        UpdateCellsLength(data);
        DrawCascadeAndRows(data);
        ResetData();
    }

    private void UpdateCellsLength(IEnumerable<TModel> data)
    {
        foreach (var item in data)
        {
            var rowValues = ConvertModelToTableValues(item);
            _convertedValuesTable.Add(rowValues);
        }
    }

    private Dictionary<PropertyInfo, string> ConvertModelToTableValues(TModel model)
    {
        var rowValues = new Dictionary<PropertyInfo, string>();
        foreach (var propertyPair in _cellsLengthUpdated)
        {
            var propertyValue = propertyPair.Key.GetValue(model);
            var propertyString = propertyValue switch
            {
                null => NullValueTable,
                DateTime dateTime => dateTime.ToString(DateFormat),
                _ => propertyValue.ToString() ?? NullValueTable
            };

            if (propertyPair.Value < propertyString.Length)
                _cellsLengthUpdated[propertyPair.Key] = propertyString.Length;

            rowValues.Add(propertyPair.Key, propertyString);
        }

        return rowValues;
    }

    private void DrawCascadeAndRows(IReadOnlyCollection<TModel> data)
    {
        DrawTableHeader();
        DrawTableData(data);
    }

    private void DrawTableHeader()
    {
        DrawDoubleMiddleRow();
        DrawHeaders();
        DrawDoubleMiddleRow();
    }

    private void DrawTableData(IReadOnlyCollection<TModel> data)
    {
        if (data.Count == 0)
        {
            DrawEmptyRow();
            DrawMiddleRow();
        }
        else
        {
            FillTable();
        }
    }

    private void FillTable()
    {
        foreach (var dataRow in _convertedValuesTable)
        {
            DrawDataRow(dataRow);
            DrawMiddleRow();
        }
    }

    private void DrawMiddleRow()
    {
        _outputHelper.DrawTableCross();
        foreach (var cell in _cellsLengthUpdated)
        {
            _outputHelper.DrawTableLineHorizontal(cell.Value + LengthSpaceAroundValue);
            _outputHelper.DrawTableCross();
        }

        _outputHelper.NewLine();
    }

    private void DrawDoubleMiddleRow()
    {
        _outputHelper.DrawTableCross();
        foreach (var cell in _cellsLengthUpdated)
        {
            _outputHelper.DrawTableLineHorizontalDouble(cell.Value + LengthSpaceAroundValue);
            _outputHelper.DrawTableCross();
        }

        _outputHelper.NewLine();
    }

    private void DrawHeaders()
    {
        _outputHelper.DrawTableLineVertical();
        foreach (var cell in _cellsLengthUpdated)
        {
            var headerName = cell.Key.GetCustomAttribute<DescriptionAttribute>()?.Description
                             ?? cell.Key.Name;

            _outputHelper.DrawValueInCell(cell.Value, headerName);
            _outputHelper.DrawTableLineVertical();
        }

        _outputHelper.NewLine();
    }

    private void DrawEmptyRow()
    {
        _outputHelper.DrawTableLineVertical();
        foreach (var cell in _cellsLengthUpdated)
        {
            _outputHelper.DrawValueInCell(cell.Value, string.Empty);
            _outputHelper.DrawTableLineVertical();
        }

        _outputHelper.NewLine();
    }

    private void DrawDataRow(Dictionary<PropertyInfo, string> dataRow)
    {
        _outputHelper.DrawTableLineVertical();
        foreach (var cell in _cellsLengthUpdated)
        {
            _outputHelper.DrawValueInCell(cell.Value, dataRow[cell.Key]);
            _outputHelper.DrawTableLineVertical();
        }

        _outputHelper.NewLine();
    }

    private void ResetData()
    {
        _cellsLengthUpdated = new Dictionary<PropertyInfo, int>(_cellsLengthBasic);
        _convertedValuesTable.Clear();
    }

    private Dictionary<PropertyInfo, int> CalculateBasicCascade()
    {
        var dictionary = new Dictionary<PropertyInfo, int>();
        foreach (var property in typeof(TModel).GetProperties())
        {
            var showAttribute = property.GetCustomAttribute<BrowsableAttribute>();
            if (showAttribute?.Browsable == false)
            {
                continue;
            }

            var propertyNameLength = property.GetCustomAttribute<DescriptionAttribute>()?.Description.Length
                                     ?? property.Name.Length;
            dictionary.Add(property, propertyNameLength);
        }

        return dictionary;
    }
}