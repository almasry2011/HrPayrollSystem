using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HrPayrollSystemFinal.Migrations
{
    public partial class AttendanceChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Continuities_Workers_WorkerId",
                table: "Continuities");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Workers_WorkerId",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPromotions_Workers_WorkerId",
                table: "WorkerPromotions");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerPromotions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkerId",
                table: "WorkerPromotions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkerId",
                table: "Vacations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId1",
                table: "Vacations",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Payrolls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkerId",
                table: "Payrolls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId1",
                table: "Payrolls",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Continuities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CurrentWorkerId",
                table: "Continuities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPromotions_CurrentWorkerId",
                table: "WorkerPromotions",
                column: "CurrentWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_WorkerId1",
                table: "Vacations",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_WorkerId1",
                table: "Payrolls",
                column: "WorkerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Continuities_CurrentWorkerId",
                table: "Continuities",
                column: "CurrentWorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Continuities_CurrentWorkPlaces_CurrentWorkerId",
                table: "Continuities",
                column: "CurrentWorkerId",
                principalTable: "CurrentWorkPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Continuities_Workers_WorkerId",
                table: "Continuities",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_CurrentWorkPlaces_WorkerId",
                table: "Payrolls",
                column: "WorkerId",
                principalTable: "CurrentWorkPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Workers_WorkerId1",
                table: "Payrolls",
                column: "WorkerId1",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_CurrentWorkPlaces_WorkerId1",
                table: "Vacations",
                column: "WorkerId1",
                principalTable: "CurrentWorkPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPromotions_CurrentWorkPlaces_CurrentWorkerId",
                table: "WorkerPromotions",
                column: "CurrentWorkerId",
                principalTable: "CurrentWorkPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPromotions_Workers_WorkerId",
                table: "WorkerPromotions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Continuities_CurrentWorkPlaces_CurrentWorkerId",
                table: "Continuities");

            migrationBuilder.DropForeignKey(
                name: "FK_Continuities_Workers_WorkerId",
                table: "Continuities");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_CurrentWorkPlaces_WorkerId",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Workers_WorkerId1",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_CurrentWorkPlaces_WorkerId1",
                table: "Vacations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPromotions_CurrentWorkPlaces_CurrentWorkerId",
                table: "WorkerPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerPromotions_Workers_WorkerId",
                table: "WorkerPromotions");

            migrationBuilder.DropTable(
                name: "CompanyViewModel");

            migrationBuilder.DropIndex(
                name: "IX_WorkerPromotions_CurrentWorkerId",
                table: "WorkerPromotions");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_WorkerId1",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_WorkerId1",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Continuities_CurrentWorkerId",
                table: "Continuities");

            migrationBuilder.DropColumn(
                name: "CurrentWorkerId",
                table: "WorkerPromotions");

            migrationBuilder.DropColumn(
                name: "CurrentWorkerId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "CurrentWorkerId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "WorkerId1",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "CurrentWorkerId",
                table: "Continuities");

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "WorkerPromotions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Payrolls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Continuities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Continuities_Workers_WorkerId",
                table: "Continuities",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Workers_WorkerId",
                table: "Payrolls",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerPromotions_Workers_WorkerId",
                table: "WorkerPromotions",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
