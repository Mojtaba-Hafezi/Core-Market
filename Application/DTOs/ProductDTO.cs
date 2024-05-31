using Domain.Entities;

namespace Application.DTOs;

public class ProductDTO
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public int? Quantity { get; set; }

    public double? FileSize { get; set; }

    public double? Weight { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

}
