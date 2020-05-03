using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBPB_Shop.EFDataAccess.Migrations
{
    public partial class something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProducersId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProducersId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProducersId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProducerId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerId",
                table: "Products",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProducerId",
                table: "Products",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_ProducerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProducerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProducersId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducersId",
                table: "Products",
                column: "ProducersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_ProducersId",
                table: "Products",
                column: "ProducersId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
