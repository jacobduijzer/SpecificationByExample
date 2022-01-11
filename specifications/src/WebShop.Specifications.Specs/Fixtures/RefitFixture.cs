using System;
using System.Net.Http;
using Refit;

namespace WebShop.Specifications.Specs.Fixtures;

public class RefitFixture<TRefitApi> : IDisposable
{
    public TRefitApi GetRestClient(string baseAddress)
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, sslErrors) => true
        };
        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(baseAddress)
        };

        return RestService.For<TRefitApi>(httpClient);
    }

    public void Dispose()
    {
    }
}