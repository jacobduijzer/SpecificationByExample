using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Api.Application;
using ProductCatalog.Domain;

namespace ProductCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    [Route("CreateOrder")]
    public IActionResult CreateOrder([FromBody] ShoppingCart shoppingCart)
    {
        var invoice = new CreateInvoiceFromShoppingBasketCommand().Handle(shoppingCart);
        return Ok(invoice);
    }
}