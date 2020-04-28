using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class QuantityProductsCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityInCart",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductsCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductsCart");

            migrationBuilder.AddColumn<int>(
                name: "QuantityInCart",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
