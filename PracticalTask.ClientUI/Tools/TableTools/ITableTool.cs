namespace PracticalTask.ClientUI.Tools.TableTools;

public interface ITableTool<TModel>
{
    public void DrawTable(IReadOnlyCollection<TModel> modelsList);
}