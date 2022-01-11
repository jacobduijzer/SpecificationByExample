using System.Collections.Generic;
using System.Threading.Tasks;
using ProductCatalog.Domain;
using Refit;

namespace WebShop.Specifications.Specs.Apis;

public interface ISearchApi
{
    [Get("/Search/{category}/{search}")]
    Task<IEnumerable<Book>> ByCategoryAndString(string category, string search);
}