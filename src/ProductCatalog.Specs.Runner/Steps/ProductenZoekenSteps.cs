using ProductCatalog.Api;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProductCatalog.Specs.Runner;

[Binding]
public class ProductenZoekenSteps : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly ScenarioContext _scenarioContext;
    private readonly ISearchApi _api;

    public ProductenZoekenSteps(
        ScenarioContext scenarioContext,
        TestWebApplicationFactory<Program> factory)
    {
        _scenarioContext = scenarioContext;
        _api = Refit.RestService.For<ISearchApi>(factory.CreateClient());
    }
    
    [Given(@"Simone wil een boek kopen met de titel ""(.*)""")]
    public void GivenSimoneWilEenBoekKopenMetDeTitel(string titel)
    {
        _scenarioContext.Add("TITLE", titel);
    }
    
    [Given(@"Simone zoekt in de categorie ""(.*)""")]
    [Given(@"ze selecteerd de categorie ""(.*)""")]
    public void GivenZeSelecteerdDeCategorie(Category category)
    {
        _scenarioContext.Add("CATEGORY", category);
    }
    
    [Given(@"Simone wil een book kopen van het formaat '(.*)'")]
    public void GivenSimoneWilEenBookKopenVanHetFormaat(BookFormat bookFormat)
    {
        _scenarioContext.Add("FORMAT", bookFormat);
    }
    
    [When(@"ze gaat zoeken")]
    public async Task WhenZeGaatZoeken()
    {
        var result = await Search();
        _scenarioContext.Add("RESULT", result);
    }

    [Then(@"krijgt ze de keuze uit de volgende boeken")]
    public async Task ThenKrijgtZeDeKeuzeUitDeVolgendeBoeken(Table bookTable)
    {
        var referenceBooks = bookTable.CreateSet<(string Titel, string Auteur, BookFormat Formaat)>();

        var result = _scenarioContext.Get<List<Book>>("RESULT");
        foreach (var book in referenceBooks)
        {
            Assert.True(
                result.Exists(x => x.Author == book.Auteur && x.Title == book.Titel && x.Format == book.Formaat));
        }
    }

    private async Task<List<Book>> Search()
    {
        SearchCriteria searchCriteria = new();

        if (_scenarioContext.ContainsKey("TITLE"))
            searchCriteria.Title = _scenarioContext.Get<string>("TITLE");
        
        if (_scenarioContext.ContainsKey("AUTHOR"))
            searchCriteria.Author = _scenarioContext.Get<string>("AUTHOR");
        
        if (_scenarioContext.ContainsKey("FORMAT"))
            searchCriteria.Format = _scenarioContext.Get<BookFormat>("FORMAT");

        if (_scenarioContext.ContainsKey("CATEGORY"))
            searchCriteria.Category = _scenarioContext.Get<Category>("CATEGORY");
        
        return await _api.Search(searchCriteria);
    }

    
}