using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Driving_School_DB.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrivingInstructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsGoneOff = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingInstructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrivingInstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_DrivingInstructors_DrivingInstructorId",
                        column: x => x.DrivingInstructorId,
                        principalTable: "DrivingInstructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrivingInstructorsCars",
                columns: table => new
                {
                    DrivingInstructorId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingInstructorsCars", x => new { x.DrivingInstructorId, x.CarId });
                    table.ForeignKey(
                        name: "FK_DrivingInstructorsCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrivingInstructorsCars_DrivingInstructors_DrivingInstructorId",
                        column: x => x.DrivingInstructorId,
                        principalTable: "DrivingInstructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "123 Main St", 5, "email@mail.com", false, "John Doe", "1234567890", new DateTime(2026, 11, 19, 22, 11, 24, 86, DateTimeKind.Local).AddTicks(652) },
                    { 2, "456 Elm St", 4, "mail@email.com", false, "Jane Smith", "0987654321", new DateTime(2026, 11, 19, 22, 11, 24, 86, DateTimeKind.Local).AddTicks(723) }
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

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DrivingInstructorId",
                table: "Clients",
                column: "DrivingInstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingInstructorsCars_CarId",
                table: "DrivingInstructorsCars",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DrivingInstructorsCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "DrivingInstructors");
        }
    }
}
