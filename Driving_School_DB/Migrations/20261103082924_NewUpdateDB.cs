using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Driving_School_DB.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Color", "LicensePlate", "Mileage", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "Red", "ABC123", 15000, "Corolla", 2020 },
                    { 2, "Honda", "Blue", "XYZ789", 20000, "Civic", 2019 }
                });

            migrationBuilder.InsertData(
                table: "DrivingInstructors",
                columns: new[] { "Id", "Address", "Category", "Email", "IsGoneOff", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[,]
                {
                    { 1, "123 Main St", 5, "email@mail.com", false, "John Doe", "1234567890", new DateTime(2026, 11, 3, 10, 29, 24, 222, DateTimeKind.Local).AddTicks(6377) },
                    { 2, "456 Elm St", 4, "mail@email.com", false, "Jane Smith", "0987654321", new DateTime(2026, 11, 3, 10, 29, 24, 222, DateTimeKind.Local).AddTicks(6418) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "DrivingInstructorId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "email@gmail.com", "Alice", "Johnson", "1234567890" },
                    { 2, 2, "mail@gmail.com", "Bob", "Smith", "1324657890" }
                });

            migrationBuilder.InsertData(
                table: "DrivingInstructorsCars",
                columns: new[] { "CarId", "DrivingInstructorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrivingInstructorsCars",
                keyColumns: new[] { "CarId", "DrivingInstructorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DrivingInstructorsCars",
                keyColumns: new[] { "CarId", "DrivingInstructorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
