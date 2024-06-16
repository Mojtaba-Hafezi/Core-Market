using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1686));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1691));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "BaseProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1532));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1537));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(1551));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(749));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(827));

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 11, 14, 4, 51, 953, DateTimeKind.Local).AddTicks(835));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
