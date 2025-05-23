using Microsoft.Extensions.Logging;

namespace Scrutor_Decoration.Decorators;

public sealed class LoggerCommandHandlerDecorator<TCommand> : ICommandHandlerAsync<TCommand>
{
    private readonly ICommandHandlerAsync<TCommand> _handler;
    private readonly ILogger<LoggerCommandHandlerDecorator<TCommand>> _logger;

    public LoggerCommandHandlerDecorator(ICommandHandlerAsync<TCommand> handler, ILogger<LoggerCommandHandlerDecorator<TCommand>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task HandleAsync(TCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await _handler.HandleAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error");

            throw;
        }
    }
}