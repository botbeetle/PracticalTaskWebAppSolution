using PracticalTask.ClientUI.Api.Models.Responses;

namespace PracticalTask.ClientUI.Api.ApiServes.BaseServices;

public interface IBaseApiService
{
    Task<ApiResponse<T>> GetAllAsync<T>();
}