using Microsoft.Extensions.Logging;

namespace Scrutor_Decoration.Decorators;

public sealed class LoggerQueryHandlerDecorator<TQuery, TResult> : IQueryHandlerAsync<TQuery, TResult> where TQuery : Query<TResult>
{
    private readonly IQueryHandlerAsync<TQuery, TResult> _handler;
    private readonly ILogger<LoggerQueryHandlerDecorator<TQuery, TResult>> _logger;

    public LoggerQueryHandlerDecorator(IQueryHandlerAsync<TQuery, TResult> handler, ILogger<LoggerQueryHandlerDecorator<TQuery, TResult>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken)
    {
        try
        {
            return await _handler.HandleAsync(query, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error");

            throw;
        }
    }
}