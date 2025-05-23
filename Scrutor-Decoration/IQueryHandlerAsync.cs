namespace Scrutor_Decoration;

public interface IQueryHandlerAsync<in TQuery, TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken token);
}