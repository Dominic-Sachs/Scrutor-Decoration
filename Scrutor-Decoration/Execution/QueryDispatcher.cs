using Microsoft.Extensions.DependencyInjection;

namespace Scrutor_Decoration.Execution;

public sealed class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> HandleAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandlerAsync<TQuery, TResponse>>();

        return handler!.HandleAsync(query, cancellationToken);
    }
}