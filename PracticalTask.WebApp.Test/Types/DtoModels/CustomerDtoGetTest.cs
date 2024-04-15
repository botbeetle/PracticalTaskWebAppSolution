using PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;
using Xunit;

namespace PracticalTask.WebApp.Test.Types.DtoModels;

public class CustomerDtoGetTest
{
    [Fact]
    public void TestCustomerDtoGet_CalculateAgeForDayBeforeAfterNow()
    {
        //Arrange + Act
        var customerBefore = new CustomerDtoGet
        {
            DateOfBirth = DateTime.Today.AddYears(-10).AddDays(-1)
        };

        var customerAfter = new CustomerDtoGet
        {
            DateOfBirth = DateTime.Today.AddYears(-10).AddDays(1)
        };

        //Assert
        Assert.True(customerBefore.Age == 10);
        Assert.True(customerAfter.Age == 9);
    }
}