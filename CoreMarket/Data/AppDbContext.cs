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

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Seed();
    
}
