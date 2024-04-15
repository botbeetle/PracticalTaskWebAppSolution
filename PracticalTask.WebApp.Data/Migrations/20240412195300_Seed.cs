using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PracticalTask.WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApartmentNumber", "DateOfBirth", "FirstName", "HouseNumber", "LastName", "PhoneNumber", "PostalCode", "StreetName", "Town" },
                values: new object[,]
                {
                    { 1, 52, new DateTime(1967, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Genesis", 50, "Morrow", "+48567687234", "02-969", "Waniliowa", "Warszawa" },
                    { 2, null, new DateTime(1995, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Sara", 63, "Wells", "+48567567764", "45-580", "Bolka", "Opole" },
                    { 3, 52, new DateTime(1958, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Aniya", 118, "Landry", "+48964234678", "02-642", "Maklakiewicza", "Warszawa" },
                    { 4, 89, new DateTime(1984, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Mary", 30, "Golden", "+48726687234", "25-102", "Agrestowa", "Kielce" },
                    { 5, null, new DateTime(2005, 4, 12, 0, 0, 0, 0, DateTimeKind.Local), "Jonah", 141, "Carter", "+48654234890", "31-999", "Soczyny", "Krakow" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
