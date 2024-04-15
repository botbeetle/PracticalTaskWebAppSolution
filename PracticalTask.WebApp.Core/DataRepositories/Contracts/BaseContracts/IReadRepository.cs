using PracticalTask.WebApp.Core.DataModels.Sheets;

namespace PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;

public interface IReadRepository<T> where T : class
{
    Task<T?> GetAsync(int id);
    Task<TResult?> GetAsync<TResult>(int id);
    Task<List<TResult>> GetAllAsync<TResult>();
    Task<SheetResult<TResult>> GetAllAsync<TResult>(SheetQuery queryParameters);
}