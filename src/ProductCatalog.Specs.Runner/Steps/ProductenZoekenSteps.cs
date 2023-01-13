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

    [Given(@"Simone wil het boek ""(.*)"" kopen")]
    public void GivenSimoneWilHetBoekKopen(string title)
    {
        _scenarioContext.Add("TITLE", title);
    }

    [When(@"Simone zoekt in de categorie ""(.*)""")]
    public async Task WhenSimoneZoektInDeCategorie(Category category)
    {
        SearchCriteria searchCriteria = new SearchCriteria
        {
            Title = _scenarioContext.Get<string>("TITLE"),
            Category = category
        };

        var result = await _api.Search(searchCriteria);
        _scenarioContext.Add("RESULT", result);
    }

    [Then(@"krijgt ze de keuze uit de volgende boeken")]
    public void ThenKrijgtZeDeKeuzeUitDeVolgendeBoeken(Table bookTable)
    {
        var referenceBooks = bookTable.CreateSet<(string Titel, string Auteur, BookFormat Formaat)>();

        var result = _scenarioContext.Get<List<Book>>("RESULT");
        foreach (var book in referenceBooks)
        {
            Assert.True(
                result.Exists(x => x.Author == book.Auteur && x.Title == book.Titel && x.Format == book.Formaat));
        }
    }
}