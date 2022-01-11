using ProductCatalog.Domain;
using ProductCatalog.Infrastructure;

namespace ProductCatalog.Api.Application;

public class SearchBooksInCategoryQuery
{
    public IEnumerable<Book> Handle(string category, string search)
    {
        if (!Enum.TryParse(category, out Category selectedCategory))
            return new List<Book>();

        return Products.Books
            .Where(x => x.Categories.Contains(selectedCategory) && 
                        (x.Title.Contains(search, StringComparison.InvariantCultureIgnoreCase) || x.Author.Contains(search, StringComparison.InvariantCultureIgnoreCase)));
    }
}