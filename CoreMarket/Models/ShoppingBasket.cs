using System.ComponentModel.DataAnnotations;

namespace CoreMarket.Models;

public class ShoppingBasket : BaseModel
{
    public List<Product> Products { get; set; } = new List<Product>();
}
