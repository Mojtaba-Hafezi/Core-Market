using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }

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

        modelBuilder.Entity<Product>()
            .HasOne<ShoppingBasket>()
            .WithMany(sb => sb.Products)
            .HasForeignKey(p => p.ShoppingBasketId);
        //TODO : What will happen if shopping basket gets deleted

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

        #endregion

        #region Properties

        modelBuilder.Entity<BaseModel>().Property(b => b.Id)
            .IsRequired();

        modelBuilder.Entity<Category>().Property(b => b.Name)
            .IsRequired();

        modelBuilder.Entity<Brand>().Property(b => b.Name)
            .IsRequired();

        modelBuilder.Entity<Brand>().Property(b => b.CategoryId)
            .IsRequired();

        modelBuilder.Entity<Product>().Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Product>().Property(p => p.Price)
            .IsRequired()
            .HasAnnotation("Range", new RangeAttribute(0, int.MaxValue) { ErrorMessage = "The {0} should be greater or equal to {1}" });

        modelBuilder.Entity<Product>().Property(p => p.Quantity)
            .IsRequired()
            .HasAnnotation("Range", new RangeAttribute(0, int.MaxValue) { ErrorMessage = "The {0} should be greater or equal to {1}" });

        modelBuilder.Entity<Product>().Property(p => p.BrandId)
            .IsRequired();

        #endregion



    }
}
