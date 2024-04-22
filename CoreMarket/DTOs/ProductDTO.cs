using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class ProductDTO
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Quantity { get; set; }

    
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}
