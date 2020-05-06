using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class NumberOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOrder",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOrder",
                table: "Orders");
        }
    }
}
