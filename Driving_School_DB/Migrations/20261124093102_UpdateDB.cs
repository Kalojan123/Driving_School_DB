using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Driving_School_DB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DrivingInstructors_DrivingInstructorId",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2026, 11, 24, 11, 31, 2, 229, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2026, 11, 24, 11, 31, 2, 229, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DrivingInstructors_DrivingInstructorId",
                table: "Clients",
                column: "DrivingInstructorId",
                principalTable: "DrivingInstructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_DrivingInstructors_DrivingInstructorId",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2026, 11, 3, 10, 29, 24, 222, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "DrivingInstructors",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2026, 11, 3, 10, 29, 24, 222, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_DrivingInstructors_DrivingInstructorId",
                table: "Clients",
                column: "DrivingInstructorId",
                principalTable: "DrivingInstructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
