using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticalTask.WebApp.Data.Models;

namespace PracticalTask.WebApp.Data.Confirgurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                FirstName = "Genesis",
                LastName = "Morrow",
                DateOfBirth = DateTime.Now.Date.AddYears(-Random.Shared.Next(18, 70)),
                Town = "Warszawa",
                StreetName = "Waniliowa",
                PostalCode = "02-969",
                HouseNumber = 50,
                ApartmentNumber = 52,
                PhoneNumber = "+48567687234"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Sara",
                LastName = "Wells",
                DateOfBirth = DateTime.Now.Date.AddYears(-Random.Shared.Next(18, 70)),
                Town = "Opole",
                StreetName = "Bolka",
                PostalCode = "45-580",
                HouseNumber = 63,
                ApartmentNumber = null,
                PhoneNumber = "+48567567764"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Aniya",
                LastName = "Landry",
                DateOfBirth = DateTime.Now.Date.AddYears(-Random.Shared.Next(18, 70)),
                Town = "Warszawa",
                StreetName = "Maklakiewicza Jana",
                PostalCode = "02-642",
                HouseNumber = 118,
                ApartmentNumber = 52,
                PhoneNumber = "+48964234678"
            },
            new Customer
            {
                Id = 4,
                FirstName = "Mary",
                LastName = "Golden",
                DateOfBirth = DateTime.Now.Date.AddYears(-Random.Shared.Next(18, 70)),
                Town = "Kielce",
                StreetName = "Agrestowa",
                PostalCode = "25-102",
                HouseNumber = 30,
                ApartmentNumber = 89,
                PhoneNumber = "+48726687234"
            },
            new Customer
            {
                Id = 5,
                FirstName = "Jonah",
                LastName = "Carter",
                DateOfBirth = DateTime.Now.Date.AddYears(-Random.Shared.Next(18, 70)),
                Town = "Krakow",
                StreetName = "Soczyny",
                PostalCode = "31-999",
                HouseNumber = 141,
                ApartmentNumber = null,
                PhoneNumber = "+48654234890"
            }
        );
    }
}