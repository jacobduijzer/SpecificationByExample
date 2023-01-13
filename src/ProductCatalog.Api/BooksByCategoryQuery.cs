namespace ProductCatalog.Api;

public record BooksByCategoryQuery(Category Category)
{
    public IEnumerable<Book> Handle() => 
                Products.Books.Where(x => x.Categories.Contains(Category));
}