using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.Application;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
   [HttpGet]
   [Route ("{category}/{search}")]
   public IActionResult Search(string category, string search)
   {
      return Ok(new SearchBooksInCategoryQuery().Handle(category, search));
   }
}