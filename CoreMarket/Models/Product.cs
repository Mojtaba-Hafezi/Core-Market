using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace CoreMarket.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "The {0} should be greater or equal to {1}")]
    public double Price { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage ="The {0} should be greater than 0")]
    public int Quantity { get; set; }

    [Required]
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int? ShoppingBasketId { get; set; }
    public ShoppingBasket? shoppingBasket { get; set; }
}
