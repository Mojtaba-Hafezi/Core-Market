using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configuringSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingBaskets");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingBasketId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingBasketId",
                table: "Products");

            migrationBuilder.EnsureSchema(
                name: "BASE");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "BASE");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brands",
                newSchema: "BASE");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands",
                column: "CategoryId",
                principalSchema: "BASE",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "BASE",
                table: "Products",
                column: "BrandId",
                principalSchema: "BASE",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "BASE",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "BASE",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "BASE",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Brands",
                schema: "BASE",
                newName: "Brands");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingBasketId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBaskets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShoppingBasketId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShoppingBasketId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShoppingBasketId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShoppingBasketId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShoppingBasketId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingBasketId",
                table: "Products",
                column: "ShoppingBasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                table: "Brands",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingBaskets_ShoppingBasketId",
                table: "Products",
                column: "ShoppingBasketId",
                principalTable: "ShoppingBaskets",
                principalColumn: "Id");
        }
    }
}
