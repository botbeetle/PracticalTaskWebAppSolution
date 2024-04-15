using System.ComponentModel;

namespace PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

public record CustomerDtoGet : CustomerDtoBase, IDto
{
    [Browsable(false)]
    public int Id { get; set; }

    private int _age;

    [Browsable(true)]
    public int Age
    {
        get
        {
            if (_age == 0)
            {
                _age = CalculateAge(DateOfBirth);
            }
            return _age;
        }
    }


    private int CalculateAge(DateTime birthdate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthdate.Year;
        if (birthdate.Date > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }


    public override string ToString()
    {
        return $"Id:{Id}; {base.ToString()}";
    }
}