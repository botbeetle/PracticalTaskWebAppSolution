using PracticalTask.WebApp.Core.DataRepositories.Contracts.BaseContracts;
using PracticalTask.WebApp.Data.Models;

namespace PracticalTask.WebApp.Core.DataRepositories.Contracts;

public interface ICustomerRepository : IReadRepository<Customer>, IWriteRepository<Customer>
{

}