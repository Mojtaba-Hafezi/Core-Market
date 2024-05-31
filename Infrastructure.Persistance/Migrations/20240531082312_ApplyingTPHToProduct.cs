using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ApplyingTPHToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "BASE");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BASE",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "BASE",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateTable(
                name: "BaseProducts",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FileSize = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseProducts_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "BASE",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "BASE",
                table: "BaseProducts",
                columns: new[] { "Id", "BrandId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Discriminator", "IsDeleted", "ModifiedAt", "ModifiedByUserId", "Name", "Price", "Quantity", "Weight" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(603), null, null, null, "PhysicalProduct", false, null, null, "S22 Ultra", 699.0, 30, 0.20999999999999999 },
                    { 2, 2, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(608), null, null, null, "PhysicalProduct", false, null, null, "Apple Watch 9", 449.0, 50, 0.080000000000000002 },
                    { 3, 3, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(611), null, null, null, "PhysicalProduct", false, null, null, "A95L", 2599.0, 10, 40.0 },
                    { 4, 4, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(614), null, null, null, "PhysicalProduct", false, null, null, "STEPPJACKE", 69.950000000000003, 250, 1.25 },
                    { 5, 7, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(617), null, null, null, "PhysicalProduct", false, null, null, "Football shoe", 79.989999999999995, 150, 0.070000000000000007 }
                });

            migrationBuilder.InsertData(
                schema: "BASE",
                table: "BaseProducts",
                columns: new[] { "Id", "BrandId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Discriminator", "FileSize", "IsDeleted", "ModifiedAt", "ModifiedByUserId", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 2, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(657), null, null, null, "DigitalProduct", 25.0, false, null, null, "Becoming", 14.99 },
                    { 7, 2, new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(661), null, null, null, "DigitalProduct", 2.0, false, null, null, "The Great Gatsby", 10.99 }
                });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(505), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(515), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(518), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(522), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(524), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(527), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(530), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(533), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(536), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(122), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(175), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                schema: "BASE",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModifiedAt", "ModifiedByUserId" },
                values: new object[] { new DateTime(2024, 5, 31, 10, 23, 12, 135, DateTimeKind.Local).AddTicks(178), null, null, null, false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_BaseProducts_BrandId",
                schema: "BASE",
                table: "BaseProducts",
                column: "BrandId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Categories_CategoryId",
                schema: "BASE",
                table: "Brands");

            migrationBuilder.DropTable(
                name: "BaseProducts",
                schema: "BASE");

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
                name: "IsDeleted",
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
                name: "IsDeleted",
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

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "BASE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "BASE",
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "BASE",
                table: "Products",
                columns: new[] { "Id", "BrandId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "S22 Ultra", 699.0, 30 },
                    { 2, 2, "Apple Watch 9", 449.0, 50 },
                    { 3, 3, "A95L", 2599.0, 10 },
                    { 4, 4, "STEPPJACKE", 69.950000000000003, 250 },
                    { 5, 7, "Football shoe", 79.989999999999995, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                schema: "BASE",
                table: "Products",
                column: "BrandId");

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
    }
}
