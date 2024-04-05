﻿using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    //public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
    //public DbSet<ProductShoppingBasket> ProductShoppingBaskets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();


        #region Relations
        modelBuilder.Entity<Product>()
            .HasOne<Brand>(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<ProductShoppingBasket>()
        //    .HasOne<Product>()
        //    .WithMany(p => p.ProductShoppingBaskets)
        //    .HasForeignKey(psb => psb.ProductId);

        //modelBuilder.Entity<ProductShoppingBasket>()
        //    .HasOne<ShoppingBasket>()
        //    .WithMany(sb => sb.ProductShoppingBaskets)
        //    .HasForeignKey(psb => psb.ShoppingBasketId);


        modelBuilder.Entity<Brand>()
            .HasOne<Category>(b => b.Category)
            .WithMany(c => c.brands)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Keys

        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Brand>().HasKey(b => b.Id);
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        //modelBuilder.Entity<ProductShoppingBasket>().HasKey(psb => new { psb.ProductId, psb.ShoppingBasket });

        #endregion


    }
}
