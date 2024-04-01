using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;

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

        modelBuilder.Entity<Product>().HasKey(p => p.Id);

        #endregion

        #region Properties

       
        #endregion



    }
}
