using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Employee.MVC.Core.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeNumber = table.Column<int>(type: "int(11)", nullable: false),
                    JobProfileId = table.Column<int>(type: "int(11)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(30)", nullable: false),
                    PinCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    Status = table.Column<ulong>(type: "bit(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "jobprofile",
                columns: table => new
                {
                    JobProfileId = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobProfileName = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobprofile", x => x.JobProfileId);
                });

            migrationBuilder.InsertData(
                table: "jobprofile",
                columns: new[] { "JobProfileId", "JobProfileName" },
                values: new object[] { 1, "Director" });

            migrationBuilder.InsertData(
                table: "jobprofile",
                columns: new[] { "JobProfileId", "JobProfileName" },
                values: new object[] { 2, "Manager" });

            migrationBuilder.InsertData(
                table: "jobprofile",
                columns: new[] { "JobProfileId", "JobProfileName" },
                values: new object[] { 3, "Trainee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "jobprofile");
        }
    }
}
