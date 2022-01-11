using System.Threading.Tasks;
using ProductCatalog.Domain;
using Refit;

namespace WebShop.Specifications.Specs.Apis;

public interface IPaymentApi
{
    [Post("/Payment/CreateOrder")]
    Task<Invoice> CreateOrder([Body] ShoppingCart shoppingCart);
}