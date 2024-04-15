using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTask.WebApp.Controllers;
using PracticalTask.WebApp.Core.DataMappers;
using PracticalTask.WebApp.Core.DataModels.Sheets;
using PracticalTask.WebApp.Core.DataRepositories.Repositories;
using PracticalTask.WebApp.Data.Contexts;
using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;
using PracticalTask.WebApp.Test.Integration.Mocks;

namespace PracticalTask.WebApp.Test.Integration.WebApp.Controllers;

public class CustomersControllerTests
{
    private readonly CustomersController _customersController;
    public CustomersControllerTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source= ..//..//..//Mocks//Stores//TestSQLite.db");
        var context = new AppDbContext(optionsBuilder.Options);
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DataMapper>());
        var mapper = new Mapper(config);
        var customerRepository = new CustomerRepository(context, mapper);
        _customersController = new CustomersController(customerRepository);
    }


    [Fact]
    public async void TestGetCustomers_ReturnAnyCustomers()
    {
        //Act
        var actionResult = await _customersController.GetCustomers();

        //Assert
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.True(((IEnumerable<CustomerDtoGet>)result.Value).Any());
    }


    [Fact]
    public async void TestGetCustomersBySheet_ReturnOneSheetOfCustomers()
    {
        //Arrange
        var sheetQuery = new SheetQuery { SheetSize = 3, SheetNumber = 0, StartIndex = 0 };

        //Act
        var actionResult = await _customersController.GetCustomersSheets(sheetQuery);

        //Assert
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        var data = (SheetResult<CustomerDtoGet>)result.Value;
        Assert.True(data.Items.Count == 3);
    }


    [Fact]
    public async void TestGetCustomerById_ReturnOneCustomer()
    {
        //Arrange
        var getCustomersResult = await _customersController.GetCustomers();

        var getCustomers = getCustomersResult.Result as OkObjectResult;
        Assert.NotNull(getCustomers);
        Assert.NotNull(getCustomers.Value);

        var customers = ((IEnumerable<CustomerDtoGet>)getCustomers.Value).ToList();
        Assert.NotNull(customers);
        Assert.True(customers.Count > 0);

        var customer = customers.Last();

        //Act
        var actionResult = await _customersController.GetCustomer(customer.Id);

        //Assert
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        var data = result.Value as CustomerDtoGet;
        Assert.NotNull(data);
        Assert.True(data.Id == customer.Id);
    }


    [Fact]
    public async void TestGetCustomerByWrongId_ReturnNotFound()
    {
        //Arrange
        var id = 1000;

        //Act
        var actionResult = await _customersController.GetCustomer(id);

        //Assert
        var result = actionResult.Result as NotFoundResult;
        Assert.NotNull(result);
    }


    [Fact]
    public async void TestPutCustomer_TryUpdatePhone_ShouldUpdatedPhone()
    {
        //Arrange
        var getCustomersResult = await _customersController.GetCustomers();

        var getCustomers = getCustomersResult.Result as OkObjectResult;
        Assert.NotNull(getCustomers);
        Assert.NotNull(getCustomers.Value);

        var customers = ((IEnumerable<CustomerDtoGet>)getCustomers.Value).ToList();
        Assert.NotNull(customers);
        Assert.True(customers.Count > 0);

        var customer = customers.Last();

        var newPhone = MockStaticData.GetRandomPhoneNumber;

        //Act
        var customerDtoUpdate = new CustomerDtoUpdate
        {
            HouseNumber = customer.HouseNumber,
            DateOfBirth = customer.DateOfBirth,
            ApartmentNumber = customer.ApartmentNumber,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Id = customer.Id,
            PhoneNumber = customer.PhoneNumber,
            PostalCode = customer.PostalCode,
            StreetName = customer.StreetName,
            Town = customer.Town,
        };

        customerDtoUpdate.PhoneNumber = newPhone;
        var putActionResult = await _customersController.PutCustomer(customer.Id, customerDtoUpdate);
        var getUpdatedCustomerResult = await _customersController.GetCustomer(customer.Id);

        //Assert
        var noContentResult = putActionResult as NoContentResult;
        Assert.NotNull(noContentResult);

        var getUpdatedObjectResult = getUpdatedCustomerResult.Result as OkObjectResult;
        Assert.NotNull(getUpdatedObjectResult);
        Assert.NotNull(getUpdatedObjectResult.Value);
        var data = getUpdatedObjectResult.Value as CustomerDtoGet;
        Assert.NotNull(data);
        Assert.True(data.PhoneNumber == newPhone);
    }

    [Fact]
    public async void TestPostCustomer_AddNewCustomer_ShouldReturnNewId()
    {
        //Arrange
        var customer = MockStaticData.GetCustomer();

        //Act
        var actionResult = await _customersController.PostCustomer(customer);

        //Assert
        var result = actionResult.Result as CreatedAtActionResult;
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        var data = result.Value as CustomerDtoGet;
        Assert.NotNull(data);
        Assert.True(data.Id > 0);
    }

    [Fact]
    public async void TestDeleteCustomer_DeleteLastCustomer_ShouldReturnNoContentResult()
    {
        //Arrange
        var getCustomersResult = await _customersController.GetCustomers();

        var getCustomers = getCustomersResult.Result as OkObjectResult;
        Assert.NotNull(getCustomers);
        Assert.NotNull(getCustomers.Value);

        var customers = ((IEnumerable<CustomerDtoGet>)getCustomers.Value).ToList();
        Assert.NotNull(customers);
        Assert.True(customers.Count > 0);

        var customer = customers.Last();

        //Act
        var actionResult = await _customersController.DeleteCustomer(customer.Id);

        //Assert
        var noContentResult = actionResult as NoContentResult;
        Assert.NotNull(noContentResult);
    }


}