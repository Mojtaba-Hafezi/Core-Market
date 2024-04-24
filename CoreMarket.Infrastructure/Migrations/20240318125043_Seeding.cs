using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreMarket.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Seeding : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products");

        migrationBuilder.DropForeignKey(
            name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
            table: "Products");

        migrationBuilder.DropIndex(
            name: "IX_Products_CategoryId",
            table: "Products");

        migrationBuilder.DropColumn(
            name: "CategoryId",
            table: "Products");

        migrationBuilder.AlterColumn<int>(
            name: "ShoppingBasketId",
            table: "Products",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AddColumn<int>(
            name: "CategoryId",
            table: "Brands",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Id", "Description", "Name" },
            values: new object[,]
            {
                { 1, "Electronics", "Electronics" },
                { 2, "Clothing", "Clothing" },
                { 3, "Sports and Outdoors", "Sports and Outdoors" }
            });

        migrationBuilder.InsertData(
            table: "Brands",
            columns: new[] { "Id", "CategoryId", "Name" },
            values: new object[,]
            {
                { 1, 1, "Samsung" },
                { 2, 1, "Apple" },
                { 3, 1, "Sony" },
                { 4, 2, "Zara" },
                { 5, 2, "H&M" },
                { 6, 2, "Tommy Hilfiger" },
                { 7, 3, "Adidas" },
                { 8, 3, "Nike" },
                { 9, 3, "Puma" }
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "BrandId", "Name", "Price", "Quantity", "ShoppingBasketId" },
            values: new object[,]
            {
                { 1, 1, "S22 Ultra", 699.0, 30, null },
                { 2, 2, "Apple Watch 9", 449.0, 50, null },
                { 3, 3, "A95L", 2599.0, 10, null },
                { 4, 4, "STEPPJACKE", 69.950000000000003, 250, null },
                { 5, 7, "Football shoe", 79.989999999999995, 150, null }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Brands_CategoryId",
            table: "Brands",
            column: "CategoryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Brands_Categories_CategoryId",
            table: "Brands",
            column: "CategoryId",
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
            table: "Products",
            column: "ShoppingBasketId",
            principalTable: "ShoppingBaskets",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Brands_Categories_CategoryId",
            table: "Brands");

        migrationBuilder.DropForeignKey(
            name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
            table: "Products");

        migrationBuilder.DropIndex(
            name: "IX_Brands_CategoryId",
            table: "Brands");

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Brands",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Categories",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Categories",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Categories",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DropColumn(
            name: "CategoryId",
            table: "Brands");

        migrationBuilder.AlterColumn<int>(
            name: "ShoppingBasketId",
            table: "Products",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.AddColumn<int>(
            name: "CategoryId",
            table: "Products",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            name: "IX_Products_CategoryId",
            table: "Products",
            column: "CategoryId");

        migrationBuilder.AddForeignKey(
            name: "FK_Products_Categories_CategoryId",
            table: "Products",
            column: "CategoryId",
            principalTable: "Categories",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
            name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
            table: "Products",
            column: "ShoppingBasketId",
            principalTable: "ShoppingBaskets",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
