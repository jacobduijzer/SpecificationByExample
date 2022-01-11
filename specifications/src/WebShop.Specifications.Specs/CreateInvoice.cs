using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductCatalog.Domain;
using ProductCatalog.Infrastructure;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebShop.Specifications.Specs.Apis;
using WebShop.Specifications.Specs.Fixtures;
using Xunit;

namespace WebShop.Specifications.Specs;

[Binding]
public class CreateInvoice : RefitFixture<IPaymentApi>
{
    private const string ReferenceBooks = "REFERENCE_BOOKS";
    private const string ShoppingCart = "SHOPPING_CART";
    private const string Invoice = "INVOICE";

    private readonly ScenarioContext _scenarioContext;
    private readonly RefitFixture<IPaymentApi> _paymentApi;

    public CreateInvoice(
        ScenarioContext scenarioContext,
        RefitFixture<IPaymentApi> paymentApi)
    {
        _scenarioContext = scenarioContext;
        _paymentApi = paymentApi;
    }

    [Given(@"the following books")]
    public void GivenTheFollowingBooks(Table table)
    {
        var referenceBooks = table.CreateSet<(string Title, string Author, string Format, decimal Price)>();
        _scenarioContext.Add(ReferenceBooks, referenceBooks);
    }

    [Given(@"Simone has a shopping cart with: '(.*)' with format '(.*)'")]
    [Given(@"it also contains '(.*)' with format '(.*)'")]
    public void GivenIHaveAShoppingCartWithWithFormat(string title, string format)
    {
        GivenIHaveAShoppingCartWithCopiesOfWithFormat(1, title, format);
    }

    [Given(@"Simone has a shopping cart with (.*) copies of '(.*)' with format '(.*)'")]
    [Given(@"it also contains (.*) copy of '(.*)' with format '(.*)'")]
    public void GivenIHaveAShoppingCartWithCopiesOfWithFormat(int amount, string title, string format)
    {
        if (!_scenarioContext.TryGetValue(ShoppingCart, out ShoppingCart shoppingCart))
            _scenarioContext.Add(ShoppingCart, new ShoppingCart());

        var book = Products.Books.First(x => x.Title.Equals(title) && x.Format.Equals(format));
        _scenarioContext.Get<ShoppingCart>(ShoppingCart).AddItem(book.BookId, amount);
    }

    [When(@"she is going to pay her order")]
    public async Task WhenIAmGoingToPayMyOrder()
    {
        var shoppingCart = _scenarioContext.Get<ShoppingCart>(ShoppingCart);
        var api = _paymentApi.GetRestClient("http://localhost:8000/api");
        var invoice = await api.CreateOrder(shoppingCart);
        _scenarioContext.Add(Invoice, invoice);
    }

    [Then(@"she should get an invoice that has the following invoice items")]
    public void ThenIShouldGetAnInvoiceThatHasTheFollowingInvoiceItems(Table table)
    {
        var expectedItems =
            table.CreateSet<(string Title, string Amount, decimal Price, decimal Discount, decimal TotalPrice)>();
        var invoice = _scenarioContext.Get<Invoice>(Invoice);

        foreach (var expectedItem in expectedItems)
        {
            Assert.True(invoice.InvoiceItems.Count(x =>
                x.Title == expectedItem.Title &&
                x.Amount == expectedItem.Amount &&
                x.Discount == expectedItem.Discount &&
                x.Price == expectedItem.Price &&
                x.TotalPrice == expectedItem.TotalPrice) == 1);
        }
    }

    [Then(@"the shipping costs should be (.*)")]
    public void ThenTheShippingCostsShouldBe(decimal expectedPriceForShipping)
    {
        var invoice = _scenarioContext.Get<Invoice>(Invoice);
        var shipping = invoice.InvoiceItems.First(x => x.Title.Contains("Shipping"));
        Assert.Equal(expectedPriceForShipping, shipping.TotalPrice);
    }
}