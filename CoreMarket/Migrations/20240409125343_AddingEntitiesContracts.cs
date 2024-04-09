using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMarket.Migrations
{
    /// <inheritdoc />
    public partial class AddingEntitiesContracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "BASE",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "BASE",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "BASE",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "BASE",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "BASE",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "BASE",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(7), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(14), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(17), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(20), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(22), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(25), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(28), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(30), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(33), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9671), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9708), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9712), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(77), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(81), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(84), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(87), null, null, null, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(90), null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedByUserId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                schema: "BASE",
                table: "Brands");
        }
    }
}
