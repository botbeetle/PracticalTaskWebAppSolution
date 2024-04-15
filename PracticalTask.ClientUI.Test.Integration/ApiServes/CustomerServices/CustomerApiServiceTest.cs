using NUnit.Framework;
using PracticalTask.ClientUI.Api.ApiServes;
using PracticalTask.ClientUI.Api.ApiWebClients;
using PracticalTask.ClientUI.Api.Settings;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

namespace PracticalTask.ClientUI.Test.Integration.ApiServes.CustomerServices;

internal class CustomerApiServiceTest
{
    // IMPORTANT: server should be run before testing

    [Test]
    public async Task TestGetAllAsync_ShouldReturnData()
    {
        //Arrange
        var setting = SettingFactory.GetSetting();
        var apiClient = ApiWebFactory.GetApiClient(setting);
        var apiService = ApiServiceFactory.GetApiService(apiClient);

        //Act
        var result = await apiService.GetAllAsync<IReadOnlyCollection<CustomerDtoGet>>();

        //Assert
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.IsFailed, Is.False);
        Assert.That(result.ErrorMessage, Is.Null);
    }

    [Test]
    public async Task TestGetAllAsync_SetWrongUrl_ShouldReturnErrorMessage()
    {
        //Arrange
        var setting = SettingFactory.GetSetting("Wrong Url", TimeSpan.FromSeconds(10));
        var apiClient = ApiWebFactory.GetApiClient(setting);
        var apiService = ApiServiceFactory.GetApiService(apiClient);

        //Act
        var result = await apiService.GetAllAsync<IReadOnlyCollection<CustomerDtoGet>>();

        //Assert
        Assert.That(result.Data, Is.Null);
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.ErrorMessage, Is.Not.Null);
    }

    [Test]
    public async Task TestGetAllAsync_SetShortTimeOut_ShouldReturnByTimeOut()
    {
        //Arrange
        var setting = SettingFactory.GetSetting("https://localhost:7130", TimeSpan.FromMicroseconds(1));
        var apiClient = ApiWebFactory.GetApiClient(setting);
        var apiService = ApiServiceFactory.GetApiService(apiClient);

        //Act
        var result = await apiService.GetAllAsync<IReadOnlyCollection<CustomerDtoGet>>();

        //Assert
        Assert.That(result.Data, Is.Null);
        Assert.That(result.IsFailed, Is.True);
        Assert.That(result.ErrorMessage, Is.Not.Null);
    }
}