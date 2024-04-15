using PracticalTask.WebApp.Dto.Validations;
using Xunit;

namespace PracticalTask.WebApp.Test.Types.Validations;

public class ValidationBirthDateAttributeTest
{

    [InlineData("1975-1-1", true)]
    [InlineData("1899-1-1", false)]
    [InlineData("2100-1-1", false)]
    [Theory]
    public async void TestIsValid_ShouldBeTrue(string date, bool validation)
    {
        //Arrange
        var datetime = DateTime.Parse(date);
        var attribute = new ValidationBirthDateAttribute();

        //Act
        var result = attribute.IsValid(datetime);

        //Assert
        Assert.True(result == validation);
    }
}