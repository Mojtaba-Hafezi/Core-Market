using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json")
            , optional: false, reloadOnChange: true)
            .Build();

        optionsBuilder.UseSqlServer(
            config.GetConnectionString("CoreMarketConnection"), x=>x.MigrationsHistoryTable("__MigrationsHistory","BASE")
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BASE");

        modelBuilder.Seed();


        #region Relations
        modelBuilder.Entity<Product>()
            .HasOne<Brand>(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Restrict);



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


    }
}
