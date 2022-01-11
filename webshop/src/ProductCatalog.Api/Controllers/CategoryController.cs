using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.Application;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Categories() => Ok(Enum.GetNames(typeof(Category)).ToList());

    [HttpGet]
    [Route("{category}")]
    public IActionResult GetAllProductsFromCategory(string category)
    {
        return Ok(new BooksByCategoryQuery().Handle(category));
    }
}