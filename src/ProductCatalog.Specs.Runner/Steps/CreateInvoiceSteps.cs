using ProductCatalog.Api;
using ProductCatalog.Specs.Runner;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProductCatalog.Specs;

[Binding]
public class CreateInvoiceSteps : IClassFixture<TestWebApplicationFactory<Program>>
{
    private const string ReferenceBooks = "REFERENCE_BOOKS";
    private const string ShoppingCart = "SHOPPING_CART";
    private const string Invoice = "INVOICE";
    
    private readonly ScenarioContext _scenarioContext;
    private readonly IPaymentApi _api;

    public CreateInvoiceSteps(
        ScenarioContext scenarioContext,
        TestWebApplicationFactory<Program> factory)
    {
        _scenarioContext = scenarioContext;
        _api = Refit.RestService.For<IPaymentApi>(factory.CreateClient());
    }

    [Given(@"the following books")]
    public void GivenTheFollowingBooks(Table bookTable)
    {
        var books = bookTable.CreateSet<(string Titel, string Auteur, BookFormat Formaat)>();
        _scenarioContext.Add(ReferenceBooks, books);
    }

    [Given(@"Simone has a shopping cart with: '(.*)' with format '(.*)'")]
    [Given(@"it also contains '(.*)' with format '(.*)'")]
    public void GivenIHaveAShoppingCartWithWithFormat(string title, BookFormat format)
    {
        GivenIHaveAShoppingCartWithCopiesOfWithFormat(1, title, format);
    }
    
    [Given(@"Simone has a shopping cart with (.*) copies of '(.*)' with format '(.*)'")]
    [Given(@"it also contains (.*) copy of '(.*)' with format '(.*)'")]
    public void GivenIHaveAShoppingCartWithCopiesOfWithFormat(int amount, string title, BookFormat format)
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
        var invoice = await _api.CreateOrder(shoppingCart);
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
                x.Title.Equals(expectedItem.Title,StringComparison.InvariantCultureIgnoreCase) &&
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