namespace Scrutor_Decoration;

public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : Query<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken token);
}