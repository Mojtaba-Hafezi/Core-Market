﻿// <auto-generated />
using System;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.Migrations
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

            modelBuilder.Entity("Domain.Entities.BaseProduct", b =>
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

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

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BaseProducts", "BASE");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseProduct");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
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
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6860),
                            IsDeleted = false,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6867),
                            IsDeleted = false,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6871),
                            IsDeleted = false,
                            Name = "Sony"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6875),
                            IsDeleted = false,
                            Name = "Zara"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6879),
                            IsDeleted = false,
                            Name = "H&M"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6883),
                            IsDeleted = false,
                            Name = "Tommy Hilfiger"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6886),
                            IsDeleted = false,
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6890),
                            IsDeleted = false,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6894),
                            IsDeleted = false,
                            Name = "Puma"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
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
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6487),
                            Description = "Electronics",
                            IsDeleted = false,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6535),
                            Description = "Clothing",
                            IsDeleted = false,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6539),
                            Description = "Sports and Outdoors",
                            IsDeleted = false,
                            Name = "Sports and Outdoors"
                        });
                });

            modelBuilder.Entity("Domain.Entities.DigitalProduct", b =>
                {
                    b.HasBaseType("Domain.Entities.BaseProduct");

                    b.Property<double>("FileSize")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("DigitalProduct");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(7007),
                            IsDeleted = false,
                            Name = "Becoming",
                            Price = 14.99,
                            FileSize = 25.0
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(7013),
                            IsDeleted = false,
                            Name = "The Great Gatsby",
                            Price = 10.99,
                            FileSize = 2.0
                        });
                });

            modelBuilder.Entity("Domain.Entities.PhysicalProduct", b =>
                {
                    b.HasBaseType("Domain.Entities.BaseProduct");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("PhysicalProduct");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6950),
                            IsDeleted = false,
                            Name = "S22 Ultra",
                            Price = 699.0,
                            Quantity = 30,
                            Weight = 0.20999999999999999
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6955),
                            IsDeleted = false,
                            Name = "Apple Watch 9",
                            Price = 449.0,
                            Quantity = 50,
                            Weight = 0.080000000000000002
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6959),
                            IsDeleted = false,
                            Name = "A95L",
                            Price = 2599.0,
                            Quantity = 10,
                            Weight = 40.0
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6966),
                            IsDeleted = false,
                            Name = "STEPPJACKE",
                            Price = 69.950000000000003,
                            Quantity = 250,
                            Weight = 1.25
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 7,
                            CreatedAt = new DateTime(2024, 6, 10, 18, 48, 44, 760, DateTimeKind.Local).AddTicks(6970),
                            IsDeleted = false,
                            Name = "Football shoe",
                            Price = 79.989999999999995,
                            Quantity = 150,
                            Weight = 0.070000000000000007
                        });
                });

            modelBuilder.Entity("Domain.Entities.BaseProduct", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("BaseProducts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("brands")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("BaseProducts");
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Navigation("brands");
                });
#pragma warning restore 612, 618
        }
    }
}
