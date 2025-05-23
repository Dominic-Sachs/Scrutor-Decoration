namespace Scrutor_Decoration.Commands;

public sealed class TestCommandHandler : ICommandHandlerAsync<TestCommand>
{
    public Task HandleAsync(TestCommand command, CancellationToken token)
    {
        return Task.CompletedTask;
    }
}