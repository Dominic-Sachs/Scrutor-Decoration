using Microsoft.Extensions.DependencyInjection;

namespace Scrutor_Decoration.Execution;

public sealed class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync<TCommand>(TCommand command, CancellationToken token = default)
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandlerAsync<TCommand>>();

        await handler.HandleAsync(command, token);
    }
}