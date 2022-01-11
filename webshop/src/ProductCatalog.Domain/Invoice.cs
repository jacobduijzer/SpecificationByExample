namespace ProductCatalog.Domain;

public class Invoice
{
   public decimal TotalAmount { get; set; }
   public List<InvoiceItem> InvoiceItems { get; set; } = new();

   public void AddInvoiceItem(InvoiceItem invoiceItem) => InvoiceItems.Add(invoiceItem);
}