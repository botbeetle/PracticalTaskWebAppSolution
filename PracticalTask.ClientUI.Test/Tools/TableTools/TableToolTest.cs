using NUnit.Framework;
using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using PracticalTask.ClientUI.Test.Mocks;
using PracticalTask.ClientUI.Tools.TableTools;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;


namespace PracticalTask.ClientUI.Test.Tools.TableTools;

internal sealed class TableToolTest
{
    private readonly ITableTool<CustomerDtoGet> _tableService;

    public TableToolTest()
    {
        IOutputConsole outputHelper = new OutputConsole();
        _tableService = new TableTool<CustomerDtoGet>(outputHelper);
    }

    [Test]
    public void TestDrawTable_SetRow_DrawWithoutError()
    {
        //Arrange
        var customers = new List<CustomerDtoGet>
        {
            MockStaticData.GetCustomer()
        };

        //Act
        _tableService.DrawTable(customers);

        //Assert
        Assert.Pass();
    }

    [Test]
    public void TestDrawTable_SetRows_DrawWithoutError()
    {
        //Arrange
        var customers = new List<CustomerDtoGet>
        {
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer()
        };

        //Act
        _tableService.DrawTable(customers);

        //Assert
        Assert.Pass();
    }
}