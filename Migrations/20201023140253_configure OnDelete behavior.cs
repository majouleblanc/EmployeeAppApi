using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAppApi.Migrations
{
    public partial class configureOnDeletebehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "0f8fad5b-d9cb-469f-a165-70867728950e",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 23, 16, 2, 53, 471, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "a3c1880c-674c-4d18-8f91-5d3608a2c937",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 23, 16, 2, 53, 467, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "f98e4d74-0f68-4aac-89fd-047f1aaca6b6",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 23, 16, 2, 53, 471, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "0f8fad5b-d9cb-469f-a165-70867728950e",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "a3c1880c-674c-4d18-8f91-5d3608a2c937",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 22, 20, 56, 29, 665, DateTimeKind.Local).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "f98e4d74-0f68-4aac-89fd-047f1aaca6b6",
                column: "DateOfJoining",
                value: new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1645));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
