namespace ProductCatalog.Api;

public record InvoiceItem(string Title, string Amount, decimal Price, decimal Discount, decimal TotalPrice);
