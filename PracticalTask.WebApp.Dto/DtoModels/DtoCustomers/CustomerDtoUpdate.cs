using System.ComponentModel.DataAnnotations;

namespace PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

public record CustomerDtoUpdate : CustomerDtoBase, IDto
{
    [Range(1, int.MaxValue, ErrorMessage = "The Id must be more 0")]
    public int Id { get; set; }

    public override string ToString()
    {
        return $"Id:{Id}; {base.ToString()}";
    }
}
