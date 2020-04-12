using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class CartIdFromDataEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Carts_CartID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Customers",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CartID",
                table: "Customers",
                newName: "IX_Customers_CartId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Carts",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Carts_CartId",
                table: "Customers",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Carts_CartId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Customers",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CartId",
                table: "Customers",
                newName: "IX_Customers_CartID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Carts_CartID",
                table: "Customers",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
