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
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6630), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6636), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6639), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6642), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6644), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6647), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6650), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6652), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6655), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6404), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6446), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6449), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6691), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6695), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6698), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6700), false });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsDeleted" },
                values: new object[] { new DateTime(2024, 4, 12, 13, 54, 14, 456, DateTimeKind.Local).AddTicks(6703), false });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "BASE",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDeleted",
                schema: "BASE",
                table: "Products",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Id",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IsDeleted",
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
        }
    }
}
