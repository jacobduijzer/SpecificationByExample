using LinqKit;

namespace ProductCatalog.Api;

public record SearchBooksInCategoryQuery(SearchCriteria SearchCriteria) 
{
    public IEnumerable<Book> Handle()
    {
        var predicate = PredicateBuilder.New<Book>(false);
        if(SearchCriteria.Category.HasValue)    
            predicate = predicate.And(book => book.Categories.Contains(SearchCriteria.Category.Value));

        if (!string.IsNullOrEmpty(SearchCriteria.Author))
            predicate = predicate.And(book => book.Author.Contains(SearchCriteria.Author, StringComparison.InvariantCultureIgnoreCase));

        if (SearchCriteria.Format.HasValue)
            predicate = predicate.And(book => book.Format.Equals(SearchCriteria.Format));

        if (!string.IsNullOrEmpty(SearchCriteria.Title))
            predicate = predicate.And(book => book.Title.Contains(SearchCriteria.Title, StringComparison.InvariantCultureIgnoreCase));

        return Products.Books.Where(predicate.Compile()).ToList();
    } 
}