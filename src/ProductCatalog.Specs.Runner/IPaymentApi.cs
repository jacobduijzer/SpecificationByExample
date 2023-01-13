using ProductCatalog.Api;
using Refit;

namespace ProductCatalog.Specs.Runner;

public interface IPaymentApi
{
    [Post("/payments")]
    Task<Invoice> CreateOrder([Body] ShoppingCart shoppingCart);
}