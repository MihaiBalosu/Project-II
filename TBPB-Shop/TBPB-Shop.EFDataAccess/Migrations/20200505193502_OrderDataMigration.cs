using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class OrderDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeDelivery = table.Column<string>(nullable: true),
                    NameDelivery = table.Column<string>(nullable: true),
                    AddressDelivery = table.Column<string>(nullable: true),
                    CityDelivery = table.Column<string>(nullable: true),
                    DistrictDelivery = table.Column<string>(nullable: true),
                    PhoneDelivery = table.Column<string>(nullable: true),
                    TypeBilling = table.Column<string>(nullable: true),
                    NameBilling = table.Column<string>(nullable: true),
                    AddressBilling = table.Column<string>(nullable: true),
                    CityBilling = table.Column<string>(nullable: true),
                    DistrictBilling = table.Column<string>(nullable: true),
                    PhoneBilling = table.Column<string>(nullable: true),
                    TypePayment = table.Column<string>(nullable: true),
                    NameCardPayment = table.Column<string>(nullable: true),
                    AmountCardPayment = table.Column<string>(nullable: true),
                    CVVCardPayment = table.Column<string>(nullable: true),
                    NumberCardPayment = table.Column<string>(nullable: true),
                    ExpireDateCardPayment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_ProductCart_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
