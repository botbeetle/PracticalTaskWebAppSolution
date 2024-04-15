using PracticalTask.ClientUI.Api.ApiServes;
using PracticalTask.ClientUI.Api.ApiWebClients;
using PracticalTask.ClientUI.Api.Settings;
using PracticalTask.ClientUI.ConsoleAction;
using PracticalTask.ClientUI.Loggers;
using PracticalTask.ClientUI.Tools;
using PracticalTask.ClientUI.Views;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;


var logger = LoggerFactory.GetLogger();

var output = ConsoleActionFactory.GetOutput();
var input = ConsoleActionFactory.GetInput();

var table = ToolsFactory.GetTableTool<CustomerDtoGet>(output);

var setting = SettingFactory.GetSetting();
var apiClient = ApiWebFactory.GetApiClient(setting, logger);
var apiService = ApiServiceFactory.GetApiService(apiClient);

var mainView = ViewFactory.GetViewManager(output, input, table, apiService, logger);

await mainView.FetchAndDisplayDataAsync();
