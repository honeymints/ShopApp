using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductsAsFavouriteJoinTableDrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAsFavourites");

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    FavouredByUsersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavouriteProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.FavouredByUsersId, x.FavouriteProductsId });
                    table.ForeignKey(
                        name: "FK_ProductUser_Products_FavouriteProductsId",
                        column: x => x.FavouriteProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Users_FavouredByUsersId",
                        column: x => x.FavouredByUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_FavouriteProductsId",
                table: "ProductUser",
                column: "FavouriteProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.CreateTable(
                name: "ProductAsFavourites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAsFavourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAsFavourites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAsFavourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAsFavourites_ProductId",
                table: "ProductAsFavourites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAsFavourites_UserId",
                table: "ProductAsFavourites",
                column: "UserId");
        }
    }
}
