namespace CoreMarket.Models;

public class ProductShoppingBasket
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int ShoppingBasketId { get; set;}
    public ShoppingBasket ShoppingBasket { get; set; }
}
