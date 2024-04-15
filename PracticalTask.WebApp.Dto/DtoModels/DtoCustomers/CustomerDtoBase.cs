using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PracticalTask.WebApp.Dto.Validations;

namespace PracticalTask.WebApp.Dto.DtoModels.DtoCustomers;

public abstract record CustomerDtoBase
{
    [Browsable(true)]
    [Description("First Name")]
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The First Name must be with the length min 2, max 255")]
    public string FirstName { get; set; }

    [Browsable(true)]
    [Description("Last Name")]
    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The Last Name must be with the length min 2, max 255")]
    public string LastName { get; set; }

    [Browsable(true)]
    [Description("Date of birth")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date of birth is required")]
    [ValidationBirthDate]
    public DateTime DateOfBirth { get; set; }

    [Browsable(true)]
    [Description("Town")]
    [Required(ErrorMessage = "Town is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The Town must be with the length min 2, max 255")]
    public string Town { get; set; }

    [Browsable(true)]
    [Description("Street Name")]
    [Required(ErrorMessage = "Street name is required")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The Street Name must be with the length min 2, max 255")]
    public string StreetName { get; set; }

    [Browsable(true)]
    [Description("House")]
    [Required(ErrorMessage = "House number is required")]
    [Range(1, int.MaxValue, ErrorMessage = "The House Number must be more 0")]
    public int HouseNumber { get; set; }

    [Browsable(true)]
    [Description("Apart.")]
    [Range(1, int.MaxValue, ErrorMessage = "The Apartment Number must be more 0")]
    public int? ApartmentNumber { get; set; }

    [Browsable(true)]
    [Description("P.Code")]
    [Required(ErrorMessage = "Postal code is required")]
    [StringLength(6, MinimumLength = 6, ErrorMessage = "The Postal Code must be with the exact length of 6.")]
    public string PostalCode { get; set; }

    [Browsable(true)]
    [Description("Phone number")]
    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "The Phone number must be with the exact length of 12.")]
    public string PhoneNumber { get; set; }


    public override string ToString()
    {
        return $"FirstName:{FirstName}; LastName:{LastName}; DateOfBirth:{DateOfBirth}; Town:{Town}; StreetName:{StreetName}; HouseNumber:{HouseNumber}; ApartmentNumber:{ApartmentNumber}; PostalCode:{PostalCode}; PhoneNumber:{PhoneNumber};";
    }
}

