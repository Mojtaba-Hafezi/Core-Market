using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ApplyingFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProducts_Brands_BrandId",
                schema: "BASE",
                table: "BaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6871));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6487));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProducts_Brands_BrandId",
                schema: "BASE",
                table: "BaseProducts",
                column: "BrandId",
                principalSchema: "BASE",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands",
                column: "CategoryId",
                principalSchema: "BASE",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProducts_Brands_BrandId",
                schema: "BASE",
                table: "BaseProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProducts_Brands_BrandId",
                schema: "BASE",
                table: "BaseProducts",
                column: "BrandId",
                principalSchema: "BASE",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands",
                column: "CategoryId",
                principalSchema: "BASE",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
