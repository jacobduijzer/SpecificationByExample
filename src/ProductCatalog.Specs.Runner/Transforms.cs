using ProductCatalog.Api;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProductCatalog.Specs.Runner;

public class Transforms
{
    [StepArgumentTransformation]
    public List<Book> BooksTransform(Table booksTable)
    {
        return default;
    } 
}