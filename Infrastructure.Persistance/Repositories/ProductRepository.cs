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

    public async Task<int> HardDelete()
    {
        SqlConnection connection = new SqlConnection(_configuration.GetValue<string>("CoreMarketConnection"));
        SqlCommand command = new SqlCommand("HardDelete",connection);
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        int deletedProductsCount = await command.ExecuteNonQueryAsync();
        connection.Close();
        return deletedProductsCount;
    }

}
