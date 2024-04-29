using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Context;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Electronics", CreatedAt = DateTime.Now },
            new Category { Id = 2, Name = "Clothing", Description = "Clothing", CreatedAt = DateTime.Now },
            new Category { Id = 3, Name = "Sports and Outdoors", Description = "Sports and Outdoors", CreatedAt = DateTime.Now }
            );

        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Samsung", CategoryId = 1, CreatedAt = DateTime.Now },
            new Brand { Id = 2, Name = "Apple", CategoryId = 1, CreatedAt = DateTime.Now },
            new Brand { Id = 3, Name = "Sony", CategoryId = 1, CreatedAt = DateTime.Now },
            new Brand { Id = 4, Name = "Zara", CategoryId = 2, CreatedAt = DateTime.Now },
            new Brand { Id = 5, Name = "H&M", CategoryId = 2, CreatedAt = DateTime.Now },
            new Brand { Id = 6, Name = "Tommy Hilfiger", CategoryId = 2, CreatedAt = DateTime.Now },
            new Brand { Id = 7, Name = "Adidas", CategoryId = 3, CreatedAt = DateTime.Now },
            new Brand { Id = 8, Name = "Nike", CategoryId = 3, CreatedAt = DateTime.Now },
            new Brand { Id = 9, Name = "Puma", CategoryId = 3, CreatedAt = DateTime.Now }
            );


        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, BrandId = 1, Name = "S22 Ultra", Quantity = 30, Price = 699, CreatedAt = DateTime.Now },
            new Product { Id = 2, BrandId = 2, Name = "Apple Watch 9", Quantity = 50, Price = 449, CreatedAt = DateTime.Now },
            new Product { Id = 3, BrandId = 3, Name = "A95L", Quantity = 10, Price = 2599, CreatedAt = DateTime.Now },
            new Product { Id = 4, BrandId = 4, Name = "STEPPJACKE", Quantity = 250, Price = 69.95, CreatedAt = DateTime.Now },
            new Product { Id = 5, BrandId = 7, Name = "Football shoe", Quantity = 150, Price = 79.99, CreatedAt = DateTime.Now }
            );
    }
}
