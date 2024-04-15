using NUnit.Framework;
using PracticalTask.ClientUI.Api.Models.Responses;
using PracticalTask.ClientUI.ConsoleAction.OutputAction;
using PracticalTask.ClientUI.Test.Mocks;
using PracticalTask.ClientUI.Tools.TableTools;
using PracticalTask.ClientUI.Views.MainViews;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

namespace PracticalTask.ClientUI.Test.Views.MainViews;

internal class MainViewTest
{
    public IView GetView(MockInputConsole mockInputConsole, MockCustomersService customersService)
    {
        var output = new OutputConsole();
        var table = new TableTool<CustomerDtoGet>(output);
        return new MainView<CustomerDtoGet>(output, mockInputConsole, table, customersService, Serilog.Log.Logger);
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public async Task TestMainViewResponse_IsWrongWithUnknownReason(string? errorMessage)
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);
        customersService.GetCustomersApiResponse = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(new List<CustomerDtoGet>(), true, errorMessage); 
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) => { userClicked++; };
        await mainView.FetchAndDisplayDataAsync();

        //Assert
        Assert.That(userClicked, Is.EqualTo(1));
    }

    [Test]
    public async Task TestMainViewResponse_IsWrongWithSomeReason()
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);

        customersService.GetCustomersApiResponse = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(new List<CustomerDtoGet>(), true, "Some error"); 
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) => { userClicked++; };
        await mainView.FetchAndDisplayDataAsync();
            
        //Assert
        Assert.That(userClicked, Is.EqualTo(1));
    }

    [Test]
    public async Task TestMainViewResponse_IsSuccess0DataRows()
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);

        customersService.GetCustomersApiResponse = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(new List<CustomerDtoGet>()); 
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) => { userClicked++; };
        await mainView.FetchAndDisplayDataAsync();
            
        //Assert
        Assert.That(userClicked, Is.EqualTo(1));
    }

    [Test]
    public async Task TestMainViewResponse_IsSuccess3DataRows()
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);

        var customers = new List<CustomerDtoGet>
        {
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer(),
        };
        customersService.GetCustomersApiResponse = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(customers);
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) => { userClicked++; };
        await mainView.FetchAndDisplayDataAsync();

        //Assert
        Assert.That(userClicked, Is.EqualTo(1));
    }

    [Test]
    public async Task TestMainViewResponse_IsFailedThenOk_1Reload()
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);

        List<CustomerDtoGet> customers = new()
        {
            MockStaticData.GetCustomer()
        };
        var responseFail = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(customers, true);
        var responseOk = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(customers);
        customersService.GetCustomersApiResponse = responseFail;
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) =>
        {
            mockInputConsole.ReadUserKeyReturn = userClicked == 1;
            customersService.GetCustomersApiResponse = responseOk;
            userClicked++;
        };

        await mainView.FetchAndDisplayDataAsync();

        //Assert
        Assert.That(userClicked, Is.EqualTo(2));
    }

    [Test]
    public async Task TestMainViewResponse_IsOkThenOk_1Reload()
    {
        //Arrange
        var customersService = new MockCustomersService();
        var mockInputConsole = new MockInputConsole();
        var mainView = GetView(mockInputConsole, customersService);

        List<CustomerDtoGet> customers = new()
        {
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer(),
            MockStaticData.GetCustomer(),
        };
        var responseOk = new ApiResponse<IReadOnlyCollection<CustomerDtoGet>>(customers);
        customersService.GetCustomersApiResponse = responseOk;
        var userClicked = 0;

        //Act
        mockInputConsole.ReadUserKeyEventClicked += (_, _) =>
        {
            mockInputConsole.ReadUserKeyReturn = userClicked == 1;
            customersService.GetCustomersApiResponse = responseOk;
            userClicked++;
        };
        await mainView.FetchAndDisplayDataAsync();

        //Assert
        Assert.That(userClicked, Is.EqualTo(2));
    }
}