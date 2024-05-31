using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace Infrastructure.Persistance.Context;

public class AppDbContext : DbContext
{
    public DbSet<BaseProduct> BaseProducts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }

    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(
            _configuration.GetValue<string>("CoreMarketConnection"), x=>x.MigrationsHistoryTable("MigrationsHistory","BASE")
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BASE");
        
        modelBuilder.Entity<DigitalProduct>();
        modelBuilder.Entity<PhysicalProduct>();

        modelBuilder.Seed();

    }
}
