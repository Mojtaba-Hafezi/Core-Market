using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Models;

public class ShoppingBasket
{
    [Key]
    public int Id { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}
