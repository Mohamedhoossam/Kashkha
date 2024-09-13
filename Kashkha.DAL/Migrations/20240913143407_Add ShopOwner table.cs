using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashkha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddShopOwnertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShopOwnerId",
                table: "products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShopOwnerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ShopOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOwners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ShopOwnerId",
                table: "products",
                column: "ShopOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShopOwnerId",
                table: "Orders",
                column: "ShopOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShopOwners_ShopOwnerId",
                table: "Orders",
                column: "ShopOwnerId",
                principalTable: "ShopOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ShopOwners_ShopOwnerId",
                table: "products",
                column: "ShopOwnerId",
                principalTable: "ShopOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShopOwners_ShopOwnerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_products_ShopOwners_ShopOwnerId",
                table: "products");

            migrationBuilder.DropTable(
                name: "ShopOwners");

            migrationBuilder.DropIndex(
                name: "IX_products_ShopOwnerId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShopOwnerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShopOwnerId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ShopOwnerId",
                table: "Orders");
        }
    }
}
