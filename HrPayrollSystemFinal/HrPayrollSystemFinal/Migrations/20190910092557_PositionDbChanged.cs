using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrPayrollSystemFinal.Migrations
{
    public partial class PositionDbChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Departments_DepartmentId",
                table: "Shops");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Shops",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Shops",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Positions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopViewModel_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopViewModel_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopViewModel_CompanyId",
                table: "ShopViewModel",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopViewModel_DepartmentId",
                table: "ShopViewModel",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Departments_DepartmentId",
                table: "Shops",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Companies_CompanyId",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Departments_DepartmentId",
                table: "Shops");

            migrationBuilder.DropTable(
                name: "ShopViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Positions");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Shops",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Shops",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Departments_DepartmentId",
                table: "Shops",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
