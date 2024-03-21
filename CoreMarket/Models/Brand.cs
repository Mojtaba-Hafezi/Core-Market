using System.ComponentModel.DataAnnotations;
namespace CoreMarket.Models;

public class Brand
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();
}
