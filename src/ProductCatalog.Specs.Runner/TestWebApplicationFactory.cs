using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ProductCatalog.Specs.Runner;

public class TestWebApplicationFactory <TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }

    public HttpClient GetClient()
    {
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ApplicationUrl")))
            return new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("ApplicationUrl"))
            };

        return CreateClient();
    }
}