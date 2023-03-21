using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<int>(type: "int", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "Department", "Email", "EmployeeNumber", "FirstName", "Gender", "IDNumber", "JobTitle", "JoinedDate", "LastName", "MaritalStatus", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "sammy@companywebapi.com", 1, "Samuel", 0, 23049700, "Software Developer", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kirigha", 1, "09776573458" },
                    { 2, new DateTime(1999, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "john@companywebapi.com", 2, "John", 0, 230465800, "Software Developer", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mwasho", 1, "0875667487" },
                    { 3, new DateTime(1985, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "jane@companywebapi.com", 3, "Jane", 1, 23049700, "Human Resource Manager", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wambui", 0, "07873274671" },
                    { 4, new DateTime(1989, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "peter@companywebapi.com", 4, "Peter", 0, 23049700, "Sales Manager", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kamau", 1, "076748624" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
