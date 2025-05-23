namespace Scrutor_Decoration.Commands;

public sealed class TestCommandHandler2 : ICommandHandlerAsync<TestCommand2, int>
{
    public Task<int> HandleAsync(TestCommand2 command, CancellationToken token)
    {
        return Task.FromResult(1);
    }
}