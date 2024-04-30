using Application.RepositoryContracts;
using Infrastructure.Persistance.Context;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetValue<string>("CoreMarketConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            #region Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            #endregion
        }
    }
}
