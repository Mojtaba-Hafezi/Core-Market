﻿// <auto-generated />
using System;
using CoreMarket.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreMarket.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8955),
                            IsDeleted = false,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8970),
                            IsDeleted = false,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8976),
                            IsDeleted = false,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8982),
                            IsDeleted = false,
                            Name = "Zara"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8987),
                            IsDeleted = false,
                            Name = "H&M"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8992),
                            IsDeleted = false,
                            Name = "Tommy Hilfiger"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8997),
                            IsDeleted = false,
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9002),
                            IsDeleted = false,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9007),
                            IsDeleted = false,
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8373),
                            Description = "Electronics",
                            IsDeleted = false,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8432),
                            Description = "Clothing",
                            IsDeleted = false,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(8438),
                            Description = "Sports and Outdoors",
                            IsDeleted = false,
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9072),
                            IsDeleted = false,
                            Name = "S22 Ultra",
                            Price = 699.0,
                            Quantity = 30
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9079),
                            IsDeleted = false,
                            Name = "Apple Watch 9",
                            Price = 449.0,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9084),
                            IsDeleted = false,
                            Name = "A95L",
                            Price = 2599.0,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9089),
                            IsDeleted = false,
                            Name = "STEPPJACKE",
                            Price = 69.950000000000003,
                            Quantity = 250
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 7,
                            CreatedAt = new DateTime(2024, 4, 18, 15, 3, 10, 585, DateTimeKind.Local).AddTicks(9093),
                            IsDeleted = false,
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreMarket.Models.Product", b =>
                {
                    b.HasOne("CoreMarket.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
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
