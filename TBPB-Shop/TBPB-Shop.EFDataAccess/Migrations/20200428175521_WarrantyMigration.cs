using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class WarrantyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WarrantyOneYear",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WarrantyTwoYears",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarrantyOneYear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WarrantyTwoYears",
                table: "Products");
        }
    }
}
