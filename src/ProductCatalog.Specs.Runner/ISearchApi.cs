using Microsoft.AspNetCore.Http;
using ProductCatalog.Api;
using Refit;

namespace ProductCatalog.Specs.Runner;

public interface ISearchApi
{
   [Get("/search")]
   Task<List<Book>> Search([AsParameters]SearchCriteria searchCriteria);
}