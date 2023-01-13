namespace ProductCatalog.Api;

public record CreateInvoiceFromShoppingBasketCommand(ShoppingCart ShoppingCart)
{
    public Invoice Handle()
    {
        var invoice = new Invoice();
        var shouldAddShipping = false;
        foreach (var shoppingCartItem in ShoppingCart.ShoppingCartItems)
        {
            var book = Products.Books.First(x => x.BookId == shoppingCartItem.BookId);
            if (book.Format.Equals(BookFormat.Hardcover))
                shouldAddShipping = true;

            var invoiceItem = new InvoiceItem(
                $"{book.Format}: {book.Title} by {book.Author}",
                $"{shoppingCartItem.Amount}x",
                book.Price, 0, shoppingCartItem.Amount * book.Price);
            invoice.AddInvoiceItem(invoiceItem);
        }

        if (shouldAddShipping)
            invoice.AddInvoiceItem(invoice.InvoiceItems.Sum(x => x.TotalPrice) >= 100
                ? new InvoiceItem("Shipping", "1x", 5.95m, 5.95m, 0m)
                : new InvoiceItem("Shipping", "1x", 5.95m, 0, 5.95m));

        invoice.TotalAmount = invoice.InvoiceItems.Sum(x => x.TotalPrice);

        return invoice;
    }
}