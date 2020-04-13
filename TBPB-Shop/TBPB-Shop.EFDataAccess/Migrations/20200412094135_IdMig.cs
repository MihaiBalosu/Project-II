using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class IdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Producers",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producers",
                newName: "ID");
        }
    }
}
