namespace Scrutor_Decoration;

public interface IQueryDispatcher
{
    Task<TResponse> HandleAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default);
}