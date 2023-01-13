namespace ProductCatalog.Specs.Runner;

public class RefitFixture<TRefitApi> : IDisposable
{
    public TRefitApi GetRestClient(string baseAddress) =>
        Refit.RestService.For<TRefitApi>(baseAddress);

    public void Dispose()
    {
    }
}