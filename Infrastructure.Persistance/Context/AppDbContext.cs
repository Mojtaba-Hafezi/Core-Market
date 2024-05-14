using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Persistance.Context;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }

    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _hostEnvironment;
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration, IHostEnvironment hostEnvironment) : base(options)
    {
        _configuration = configuration;
        _hostEnvironment = hostEnvironment;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (_hostEnvironment.IsDevelopment())
        //{
        //    optionsBuilder.UseSqlServer(
        //    _configuration.GetValue<string>("CoreMarketConnection"), x => x.MigrationsHistoryTable("MigrationsHistory", "BASE")
        //    );
        //}
        //else
        //{
        //    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        //    var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        //    var connectionString = $"Server={dbHost}; Database={dbName}; Trusted_Connection=True; TrustServerCertificate=True;";
        //    optionsBuilder.UseSqlServer(
        //        );
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BASE");

        modelBuilder.Seed();

    }
}
