namespace PracticalTask.WebApp.Data.Models;

public sealed record Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string Town { get; set; }
    public string StreetName { get; set; }
    public int HouseNumber { get; set; }
    public int? ApartmentNumber { get; set; }
    public string PostalCode { get; set; }

    public string PhoneNumber { get; set; }

}