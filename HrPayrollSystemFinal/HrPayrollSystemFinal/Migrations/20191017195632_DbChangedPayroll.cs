using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrPayrollSystemFinal.Migrations
{
    public partial class DbChangedPayroll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPaidSalaries",
                table: "Payrolls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPaidSalaries",
                table: "Payrolls");
        }
    }
}
