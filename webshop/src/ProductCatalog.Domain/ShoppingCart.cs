namespace ProductCatalog.Domain;

public class ShoppingCart
{
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();

    public void AddItem(Guid bookId, int amount) =>
        ShoppingCartItems.Add(new ShoppingCartItem(bookId, amount));
}