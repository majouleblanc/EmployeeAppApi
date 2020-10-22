using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeAppApi.Migrations
{
    public partial class _1stmigrationcreatingthedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    DateOfJoining = table.Column<DateTime>(nullable: false),
                    PhotoFileName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { "66774006-2371-4d5b-8518-2177bcf3f73e", "HR" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { "24fd81f8-d58a-4bcc-9f35-dc6cd5641906", "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { "261e1685-cf26-494c-b17c-3546e65f5620", "Payroll" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "DepartmentId", "Name", "PhotoFileName" },
                values: new object[] { "a3c1880c-674c-4d18-8f91-5d3608a2c937", new DateTime(2020, 10, 22, 20, 56, 29, 665, DateTimeKind.Local).AddTicks(9412), "24fd81f8-d58a-4bcc-9f35-dc6cd5641906", "youssef nabet", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "DepartmentId", "Name", "PhotoFileName" },
                values: new object[] { "f98e4d74-0f68-4aac-89fd-047f1aaca6b6", new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1645), "261e1685-cf26-494c-b17c-3546e65f5620", "Aaron Baetens", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "DepartmentId", "Name", "PhotoFileName" },
                values: new object[] { "0f8fad5b-d9cb-469f-a165-70867728950e", new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1680), "261e1685-cf26-494c-b17c-3546e65f5620", "Vincent Nys", null });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
