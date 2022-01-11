using ProductCatalog.Domain;
using ProductCatalog.Infrastructure;

namespace ProductCatalog.Api.Application;

public class BooksByCategoryQuery
{
    public IEnumerable<Book> Handle(string category)
    {
        if (!Enum.TryParse(category, out Category selectedCategory))
            return new List<Book>();

        return Products.Books.Where(x => x.Categories.Contains(selectedCategory));
    }
}