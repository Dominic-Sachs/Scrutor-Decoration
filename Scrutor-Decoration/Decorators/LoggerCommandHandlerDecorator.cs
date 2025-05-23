using Microsoft.Extensions.Logging;

namespace Scrutor_Decoration.Decorators;

public sealed class LoggerCommandHandlerDecorator<TCommand> : ICommandHandlerAsync<TCommand> where TCommand : Command
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

public sealed class LoggerCommandHandlerDecorator<TCommand, TResult> : ICommandHandlerAsync<TCommand, TResult> where TCommand : Command<TResult>
{
    private readonly ICommandHandlerAsync<TCommand, TResult> _handler;
    private readonly ILogger<LoggerCommandHandlerDecorator<TCommand>> _logger;

    public LoggerCommandHandlerDecorator(ICommandHandlerAsync<TCommand, TResult> handler, ILogger<LoggerCommandHandlerDecorator<TCommand>> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    public async Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken)
    {
        try
        {
            return await _handler.HandleAsync(command, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error");

            throw;
        }
    }
}