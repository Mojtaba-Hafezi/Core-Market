using CoreMarket.Models;
using Microsoft.EntityFrameworkCore;

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
            config.GetConnectionString("CoreMarketConnection"), x=>x.MigrationsHistoryTable("MigrationsHistory","BASE")
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BASE");

        modelBuilder.Seed();

    }
}
