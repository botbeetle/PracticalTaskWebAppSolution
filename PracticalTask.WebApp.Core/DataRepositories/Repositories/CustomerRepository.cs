using AutoMapper;
using PracticalTask.WebApp.Core.DataRepositories.Contracts;
using PracticalTask.WebApp.Core.DataRepositories.Repositories.BaseRepositories;
using PracticalTask.WebApp.Data.Contexts;
using PracticalTask.WebApp.Data.Models;

namespace PracticalTask.WebApp.Core.DataRepositories.Repositories;

public sealed class CustomerRepository : DataRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}