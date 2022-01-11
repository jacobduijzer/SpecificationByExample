using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebShop.Specifications.Specs.Apis;
using WebShop.Specifications.Specs.Fixtures;
using Xunit;

namespace WebShop.Specifications.Specs;

[Binding]
public class ProductenZoeken : RefitFixture<ISearchApi>
{
    private readonly ScenarioContext _scenarioContext;
    private readonly RefitFixture<ISearchApi> _searchApi;

    public ProductenZoeken(
        ScenarioContext scenarioContext,
        RefitFixture<ISearchApi> searchApi)
    {
        _scenarioContext = scenarioContext;
        _searchApi = searchApi;
    }

    [Given(@"Simone wil het boek ""(.*)"" kopen")]
    public void GivenSimoneWilHetBoekKopen(string searchString)
    {
        _scenarioContext.Add("SEARCH_STRING", searchString);
    }

    [When(@"Simone zoekt in de categorie ""(.*)""")]
    public void WhenSimoneZoektInDeCategorie(string category)
    {
        _scenarioContext.Add("CATEGORY", category);
    }

    [Then(@"krijgt ze de keuze uit de volgende boeken")]
    public async Task ThenKrijgtZeDeKeuzeUitDeVolgendeBoeken(Table table)
    {
        var expectedResult = table.CreateSet<BookResult>();
        var category = _scenarioContext.Get<string>("CATEGORY");
        var searchString = _scenarioContext.Get<string>("SEARCH_STRING");
        var api = _searchApi.GetRestClient("http://localhost/api");
        var result = await api.ByCategoryAndString(category, searchString);
        
        Assert.NotNull(result);
        Assert.Equal(expectedResult.Count(), result.Count());
        foreach(var expected in expectedResult)
            Assert.True(result.Count(x => 
                x.Author == expected.Author &&
                x.Title == expected.Title && 
                x.Format == expected.Format) == 1);
    }
}