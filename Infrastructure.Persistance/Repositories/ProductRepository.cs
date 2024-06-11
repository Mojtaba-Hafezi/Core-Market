using Application.RepositoryContracts;
using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Persistance.Repositories;

public class ProductRepository : GenericRepository<BaseProduct>, IProductRepository
{
    private readonly IConfiguration _configuration;
    public ProductRepository(AppDbContext appDbContext, IConfiguration configuration) : base(appDbContext)
    {
        _configuration = configuration;
    }

    public async Task<int> GetDeletedProductCount()
    {
        SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("CoreMarketConnection"));
        SqlCommand command = new SqlCommand("DeletedProductCount", connection);
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        int deletedProductsCount = Convert.ToInt32( await command.ExecuteScalarAsync());
        connection.Close();
        return deletedProductsCount;
    }

}
