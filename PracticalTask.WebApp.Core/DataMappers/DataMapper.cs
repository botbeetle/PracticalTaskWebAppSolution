using AutoMapper;
using PracticalTask.WebApp.Data.Models;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

namespace PracticalTask.WebApp.Core.DataMappers;

public sealed class DataMapper : Profile
{
    public DataMapper()
    {
        CreateMap<Customer, CustomerDtoGet>().ReverseMap();
        CreateMap<Customer, CustomerDtoUpdate>().ReverseMap();
        CreateMap<Customer, CustomerDtoCreate>().ReverseMap();
    }
}