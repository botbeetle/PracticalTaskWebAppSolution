using PracticalTask.WebApp.Dto.DtoModels;

namespace PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;

public interface IWriteRepository<T> where T : class
{
    Task<TResult> CreateAsync<TSource, TResult>(TSource source);
    Task<bool> UpdateAsync<TSource>(int id, TSource source) where TSource : IDto;
    Task<bool> DeleteAsync(int id);
}