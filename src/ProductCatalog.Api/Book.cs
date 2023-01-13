using System.Text.Json.Serialization;

namespace ProductCatalog.Api;

public record Book(Guid BookId, string Title, string Author, BookFormat Format, List<Category> Categories, decimal Price); 