using Microsoft.EntityFrameworkCore.Migrations;

namespace HrPayrollSystemFinal.Migrations
{
    public partial class SecondInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSalary",
                table: "Payrolls",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSalary",
                table: "Payrolls",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
