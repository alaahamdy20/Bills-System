using Microsoft.EntityFrameworkCore.Migrations;

namespace Bills_System.Migrations
{
    public partial class CompanyTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_Companies_CompanyId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_CompanyId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Types");

            migrationBuilder.CreateTable(
                name: "CompanyType",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "int", nullable: false),
                    TypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyType", x => new { x.CompaniesId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_CompanyType_Companies_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyType_Types_TypesId",
                        column: x => x.TypesId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyType_TypesId",
                table: "CompanyType",
                column: "TypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyType");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Types",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_CompanyId",
                table: "Types",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Companies_CompanyId",
                table: "Types",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
