namespace PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;

public interface IDataRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
{
}