using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace CoreMarket.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public List<ProductShoppingBasket> ProductShoppingBaskets { get; set; }
}
