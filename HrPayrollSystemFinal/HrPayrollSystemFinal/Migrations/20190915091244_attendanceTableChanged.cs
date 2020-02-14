using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrPayrollSystemFinal.Migrations
{
    public partial class attendanceTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Continuities_Reasons_ReasonId",
                table: "Continuities");

            migrationBuilder.DropIndex(
                name: "IX_Continuities_ReasonId",
                table: "Continuities");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "Continuities");

            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "Continuities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonName",
                table: "Continuities",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PositionViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionViewModel_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PositionViewModel_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PositionViewModel_CompanyId",
                table: "PositionViewModel",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionViewModel_DepartmentId",
                table: "PositionViewModel",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PositionViewModel");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Continuities");

            migrationBuilder.DropColumn(
                name: "ReasonName",
                table: "Continuities");

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "Continuities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continuities_ReasonId",
                table: "Continuities",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Continuities_Reasons_ReasonId",
                table: "Continuities",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
