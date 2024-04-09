﻿// <auto-generated />
using System;
using CoreMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreMarket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240409125343_AddingEntitiesContracts")]
    partial class AddingEntitiesContracts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("BASE")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreMarket.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Brands", "BASE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(7),
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(14),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(17),
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(20),
                            Name = "Zara"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(22),
                            Name = "H&M"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(25),
                            Name = "Tommy Hilfiger"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(28),
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(30),
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(33),
                            Name = "Puma"
                        });
                });

            modelBuilder.Entity("CoreMarket.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", "BASE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9671),
                            Description = "Electronics",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9708),
                            Description = "Clothing",
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 102, DateTimeKind.Local).AddTicks(9712),
                            Description = "Sports and Outdoors",
                            Name = "Sports and Outdoors"
                        });
                });

            modelBuilder.Entity("CoreMarket.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products", "BASE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(77),
                            Name = "S22 Ultra",
                            Price = 699.0,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(81),
                            Name = "Apple Watch 9",
                            Price = 449.0,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(84),
                            Name = "A95L",
                            Price = 2599.0,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(87),
                            Name = "STEPPJACKE",
                            Price = 69.950000000000003,
                            Quantity = 250
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 7,
                            CreatedAt = new DateTime(2024, 4, 9, 14, 53, 43, 103, DateTimeKind.Local).AddTicks(90),
                            Name = "Football shoe",
                            Price = 79.989999999999995,
                            Quantity = 150
                        });
                });

            modelBuilder.Entity("CoreMarket.Models.Brand", b =>
                {
                    b.HasOne("CoreMarket.Models.Category", "Category")
                        .WithMany("brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreMarket.Models.Product", b =>
                {
                    b.HasOne("CoreMarket.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CoreMarket.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CoreMarket.Models.Category", b =>
                {
                    b.Navigation("brands");
                });
#pragma warning restore 612, 618
        }
    }
}
