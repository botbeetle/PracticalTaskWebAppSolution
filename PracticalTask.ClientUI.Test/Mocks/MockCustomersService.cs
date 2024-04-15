using PracticalTask.ClientUI.Api.ApiServes.CustomerServices;
using PracticalTask.ClientUI.Api.Models.Responses;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

namespace PracticalTask.ClientUI.Test.Mocks;

internal sealed class MockCustomersService : ICustomerApiService
{
    public ApiResponse<IReadOnlyCollection<CustomerDtoGet>> GetCustomersApiResponse { get; set; }

    public Task<ApiResponse<T>> GetAllAsync<T>()
    {
        throw new NotImplementedException();
    }
}