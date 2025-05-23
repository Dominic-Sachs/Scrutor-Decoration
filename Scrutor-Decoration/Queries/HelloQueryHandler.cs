namespace Scrutor_Decoration.Queries;

public sealed class HelloQueryHandler : IQueryHandlerAsync<HelloQuery, string>
{
    public Task<string> HandleAsync(HelloQuery query, CancellationToken token)
    {
        return Task.FromResult($"Hello {query.Name}");
    }
}