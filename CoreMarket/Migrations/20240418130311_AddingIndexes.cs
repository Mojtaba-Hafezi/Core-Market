using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddingIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "BASE",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BASE",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BASE",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BASE",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8955), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8970), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8976), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8982), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8987), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8992), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8997), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9002), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9007), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8373), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8432), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8438), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9072), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9079), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9084), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9089), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9093), false });

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands",
                column: "CategoryId",
                principalSchema: "BASE",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "BASE",
                table: "Products",
                column: "BrandId",
                principalSchema: "BASE",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(7));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(20));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(22));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(33));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9712));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(87));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(90));

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
    }
}
