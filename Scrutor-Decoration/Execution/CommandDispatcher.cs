using Microsoft.Extensions.DependencyInjection;

namespace Scrutor_Decoration.Execution;

public sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync<TCommand>(TCommand command, CancellationToken token = default) where TCommand : Command
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandlerAsync<TCommand>>();

        await handler.HandleAsync(command, token);
    }

    public async Task<TResult> HandleAsync<TCommand, TResult>(TCommand command, CancellationToken token = default) where TCommand : Command<TResult>
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandlerAsync<TCommand, TResult>>();

        return await handler.HandleAsync(command, token);
    }
}