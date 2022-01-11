namespace ProductCatalog.Domain;

public record Book(Guid BookId, string Title, string Author, string Format, List<Category> Categories, decimal Price); 